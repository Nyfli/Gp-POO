using UnityEngine;

public class Potion : Item
{
    protected override void Effect()
    {
        PotionManager.Instance.AddPotion();
        Debug.Log("Potion collectée !");
    }
}
