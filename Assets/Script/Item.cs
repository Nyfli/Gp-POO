using UnityEngine;
using NaughtyAttributes;

public abstract class Item : MonoBehaviour
{
    [SerializeField, Tag] private string targetedTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetedTag))
        {
            Effect();
            Destroy(gameObject);
        }
    }

    protected abstract void Effect();
}
