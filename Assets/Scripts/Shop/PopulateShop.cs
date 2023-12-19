using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateShop : MonoBehaviour
{
    [SerializeField] private bool isSell;
    [SerializeField] private AudioClip canBuy;
    [SerializeField] private AudioClip cantBuy;
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private GameObject coinPrefab;

    private void OnEnable()
    {
        if (isSell)
        {
            PopulateSell();
        } else
        {
            PopulateBuy();
        }
    }

    private void PopulateBuy()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        foreach (OutfitType ot in InventoryManager.instance.outfits)
        {
            foreach (Outfit of in ot.outfits)
            {
                if (of.isLocked)
                {
                    GameObject item = Instantiate(itemPrefab);
                    item.transform.SetParent(transform, false);

                    item.transform.Find("Icon").gameObject.GetComponent<Image>().sprite = of.idle;

                    for (int i = 0; i < of.price; i++)
                    {
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.SetParent(item.transform.Find("Price"));
                        coin.transform.localScale = Vector3.one;
                    }

                    Destroy(item.gameObject.GetComponent<ItemSell>());

                    ItemBuy itemBuy = item.gameObject.GetComponent<ItemBuy>();
                    itemBuy.price = of.price;
                    itemBuy.type = ot.name;
                    itemBuy.outfitName = of.outfitName;
                }
            }
        }
    }

    private void PopulateSell()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        foreach (OutfitType ot in InventoryManager.instance.outfits)
        {
            foreach (Outfit of in ot.outfits)
            {
                if (!of.isLocked)
                {
                    GameObject item = Instantiate(itemPrefab);
                    item.transform.SetParent(transform, false);

                    item.transform.Find("Icon").gameObject.GetComponent<Image>().sprite = of.idle;

                    for (int i = 0; i < of.price; i++)
                    {
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.SetParent(item.transform.Find("Price"));
                        coin.transform.localScale = Vector3.one;
                    }

                    Destroy(item.gameObject.GetComponent<ItemBuy>());

                    ItemSell itemSell = item.gameObject.GetComponent<ItemSell>();
                    itemSell.price = of.price;
                    itemSell.type = ot.name;
                    itemSell.outfitName = of.outfitName;
                }
            }
        }
    }
}
