using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSell : MonoBehaviour
{
    [SerializeField] private AudioClip canSell;

    public string type;
    public string outfitName;
    public int price;

    public void OnClick()
    {
        GameManager.instance.AddCoins(price);
        AudioManager.instance.PlaySound(canSell);
        Destroy(gameObject);
        InventoryManager.instance.LockOutfit(type, outfitName);
    }
}
