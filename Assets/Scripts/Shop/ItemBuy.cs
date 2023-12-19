using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBuy : MonoBehaviour
{
    [SerializeField] private string type;
    [SerializeField] private string outfitName;
    [SerializeField] private int price;
    [SerializeField] private AudioClip canBuy;
    [SerializeField] private AudioClip cantBuy;

    public void OnClick()
    {
        if (!GameManager.instance.HasCoins(price))
        {
            AudioManager.instance.PlaySound(cantBuy);
            return;
        }

        GameManager.instance.RemoveCoins(price);
        AudioManager.instance.PlaySound(canBuy);
        Destroy(gameObject);
        InventoryManager.instance.UnlockOutfit(type, outfitName);
    }
}
