using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetInventoryItem : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Image border;

    private string type, outfitName;

    public void ChangeItem(Sprite sprite, string type, string outfitName)
    {
        image.sprite = sprite;
        image.gameObject.SetActive(true);
        this.type = type;
        this.outfitName = outfitName;
    }

    public void Click()
    {
        PlayerMovement.instance.gameObject.GetComponent<OutfitSwitcher>().ChangeOutfit(type, outfitName);
    }
}
