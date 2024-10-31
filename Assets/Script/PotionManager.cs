using UnityEngine;
using TMPro;

public class PotionManager : MonoBehaviour
{
    public static PotionManager Instance { get; private set; }

    private int potionCount = 0;

    [SerializeField] private TextMeshProUGUI potionCountText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddPotion()
    {
        potionCount++;
        UpdatePotionUI();
    }

    private void UpdatePotionUI()
    {
        if (potionCountText != null)
        {
            potionCountText.text = "Potions: " + potionCount;
        }
    }
}
