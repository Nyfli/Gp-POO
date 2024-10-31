using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TriggerController : MonoBehaviour
{

    [SerializeField] private UnityEvent _onTriggerEvent;
    [SerializeField] private bool _timingEvent;
    [SerializeField] private float _speedTrigger;

    Coroutine c;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            if (!_timingEvent)
            {
                _onTriggerEvent.Invoke();

            }

            else
            {
                c = StartCoroutine(DurableEvent());
            }
        }
    }

    IEnumerator DurableEvent()
    {
        while (true)
        {
            _onTriggerEvent.Invoke();
            yield return new WaitForSeconds(_speedTrigger);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerMovement>(out PlayerMovement player) && _timingEvent)
        {
            StopCoroutine(c);
        }
    }
}
