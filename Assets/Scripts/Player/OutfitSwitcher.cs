using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OutfitSwitcher : MonoBehaviour
{
    public void ChangeOutfit(string type, string name)
    {
        OutfitType ot = InventoryManager.instance.outfits.FirstOrDefault(t => t.name == type);

        if (ot != null)
        {
            Outfit of = ot.outfits.FirstOrDefault(o => o.outfitName == name);

            if (of != null && !of.isLocked)
            {
                ot.animator.gameObject.GetComponent<SpriteRenderer>().sprite = of.idle;
                ot.animator.runtimeAnimatorController = of.controller;
            }
        }
    }

    public void RestartOutfit()
    {
        foreach (OutfitType ot in InventoryManager.instance.outfits)
        {
            ot.animator.runtimeAnimatorController = null;
            ot.animator.gameObject.GetComponent<SpriteRenderer>().sprite = null;
        }
    }
}
