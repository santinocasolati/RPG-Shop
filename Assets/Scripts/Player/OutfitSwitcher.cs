using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OutfitSwitcher : MonoBehaviour
{
    public CurrentOutfit currentOutfit;

    private void Awake()
    {
        currentOutfit = new CurrentOutfit();
    }

    public void ChangeOutfit(OutfitType type, string name)
    {
        OutfitSection ot = InventoryManager.instance.outfits.FirstOrDefault(t => t.type == type);

        if (ot != null)
        {
            Outfit of = ot.outfits.FirstOrDefault(o => o.outfitName == name);

            if (of != null && !of.isLocked)
            {
                RestartType(ot);
                ot.animator.gameObject.GetComponent<SpriteRenderer>().sprite = of.idle;
                ot.animator.runtimeAnimatorController = of.controller;
                AssignCurrentOutfitProperties(ot.type, of.idle);
            }
        }
    }

    private void AssignCurrentOutfitProperties(OutfitType type, Sprite outfit)
    {
        switch (type)
        {
            case OutfitType.Clothes:
                currentOutfit.clothes = outfit;
                break;
            case OutfitType.Hair:
                currentOutfit.hair = outfit;
                break;
            case OutfitType.Hat:
                currentOutfit.hat = outfit;
                break;
            default:
                break;
        }
    }

    public void RestartOutfit()
    {
        foreach (OutfitSection ot in InventoryManager.instance.outfits)
        {
            RestartType(ot);
        }
    }

    public void RestartType(OutfitSection ot)
    {
        ot.animator.runtimeAnimatorController = null;
        ot.animator.gameObject.GetComponent<SpriteRenderer>().sprite = null;
        AssignCurrentOutfitProperties(ot.type, null);
    }
}

[System.Serializable]
public class CurrentOutfit
{
    public Sprite clothes;
    public Sprite hair;
    public Sprite hat;
}
