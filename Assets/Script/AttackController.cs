using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackController : MonoBehaviour
{
    [SerializeField] private InputActionReference attackAction;
    [SerializeField] private int attackDamage = 10;
    [SerializeField] private ParticleSystem attackParticleEffect;

    private Animator animator;
    private List<Health> targetsInRange = new List<Health>();

    private void Start()
    {
        animator = GetComponentInParent<Animator>();

        attackAction.action.Enable();
        attackAction.action.performed += OnAttack;
    }

    private void OnDestroy()
    {
        attackAction.action.performed -= OnAttack;
        attackAction.action.Disable();
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
        // D�clencher l'animation d'attaque
        if (animator != null)
        {
            animator.SetTrigger("Attack");
        }

        // Jouer l'effet de particules d'attaque (ne marche pas je sais pas pourquoi)
        if (attackParticleEffect != null)
        {
            attackParticleEffect.Play();
        }

        // Infliger des d�g�ts aux cibles dans la zone d'attaque
        foreach (Health target in targetsInRange)
        {
            target.takeDamage(attackDamage);
            // Jouer l'effet de particules sur l'ennemi touch� (ne marche pas �galement, je pense que le soucis vien du prefab d'animation que je met)
            target.PlayHitParticleEffect();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Health>(out Health targetHealth))
        {
            // �viter de s'infliger des d�g�ts � soi-m�me
            if (targetHealth != GetComponentInParent<Health>())
            {
                if (!targetsInRange.Contains(targetHealth))
                {
                    targetsInRange.Add(targetHealth);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Health>(out Health targetHealth))
        {
            if (targetsInRange.Contains(targetHealth))
            {
                targetsInRange.Remove(targetHealth);
            }
        }
    }
}
