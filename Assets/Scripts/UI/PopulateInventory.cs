using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateInventory : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab;

    private void OnEnable()
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

                    item.GetComponent<SetInventoryItem>().ChangeItem(of.idle, ot.name, of.outfitName);
                }
            }
        }
    }
}
