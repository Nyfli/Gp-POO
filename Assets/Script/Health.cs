using UnityEngine;
using NaughtyAttributes;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField, MinValue(0), MaxValue(100)] private int maxHealth = 100;

    [SerializeField]
    private bool showLife;

    [ShowIf("showLife"), ProgressBar("currentHealth", "maxHealth", EColor.Red), SerializeField, MaxValue(100), MinValue(0)]
    private int currentHealth;

    [SerializeField] private Slider _healthBar;

    [Header("Particle Effects")]
    [SerializeField] private ParticleSystem takeDamageParticleEffect;
    [SerializeField] private ParticleSystem healParticleEffect;

    private bool canHeal = true;

    private float regenCooldown = 1f;
    private float lastDamageTime;

    void Start()
    {
        showLife = true;
        life();
        InitializeLifeBar();
    }

    void Update()
    {
        die();
        BaseHealing();
    }

    private void life()
    {
        currentHealth = maxHealth;
    }

    public void takeDamage(int value)
    {
        if (currentHealth > 0)
        {
            currentHealth -= value;
            lastDamageTime = Time.time;
            if (_healthBar != null)
            {
                _healthBar.value = currentHealth;
            }

            // Jouer l'effet de particules de dégâts (marche pas, encore et toujours)
            if (takeDamageParticleEffect != null)
            {
                takeDamageParticleEffect.gameObject.SetActive(true);
                takeDamageParticleEffect.Play();
            }
        }
        else if (currentHealth <= 0)
        {
            Debug.Log("t'es mort");
        }
    }

    public void takeHeal(int value)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += value;
            lastDamageTime = Time.time;
            if (_healthBar != null)
            {
                _healthBar.value = currentHealth;
            }

            // Jouer l'effet de particules de guérison (ne marche pas, comme toutes les animations, SUPER!)
            if (healParticleEffect != null)
            {
                healParticleEffect.gameObject.SetActive(true);
                healParticleEffect.Play();
            }
        }
    }

    // Méthode pour jouer l'effet de particules lorsque l'ennemi est touché (ne marche pas :()
    public void PlayHitParticleEffect()
    {
        if (takeDamageParticleEffect != null)
        {
            takeDamageParticleEffect.gameObject.SetActive(true);
            takeDamageParticleEffect.Play();
        }
    }

    public void BaseHealing()
    {
        if (Time.time - lastDamageTime >= regenCooldown && canHeal)
        {
            StartCoroutine(baseregen());
        }
    }

    public IEnumerator baseregen()
    {
        canHeal = false;
        yield return new WaitForSeconds(0.5f);
        currentHealth += 1;
        if (_healthBar != null)
        {
            _healthBar.value = currentHealth;
        }

        // Jouer l'effet de particules de guérison automatique (marche pas LOL TROP BIEN)
        if (healParticleEffect != null)
        {
            healParticleEffect.gameObject.SetActive(true);
            healParticleEffect.Play();
        }

        canHeal = true;
    }

    private void die()
    {
        if (currentHealth <= 0)
        {
            Debug.Log("t'es mort");
            Destroy(gameObject);
        }
    }

    private void InitializeLifeBar()
    {
        if (_healthBar != null)
        {
            _healthBar.maxValue = maxHealth;
            _healthBar.value = currentHealth;
        }
    }
}
