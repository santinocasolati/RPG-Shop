using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBuy : MonoBehaviour
{
    [SerializeField] private AudioClip canBuy;
    [SerializeField] private AudioClip cantBuy;

    public int price;
    public string type;
    public string outfitName;

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
