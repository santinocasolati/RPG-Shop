using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public OutfitSection[] outfits;

    private void Awake()
    {
        instance = this;
    }

    public void UnlockOutfit(OutfitType type, string outfitName)
    {
        OutfitSection ot = outfits.FirstOrDefault(t => t.type == type);

        if (ot != null)
        {
            Outfit of = ot.outfits.FirstOrDefault(o => o.outfitName == outfitName);

            if (of != null)
            {
                of.isLocked = false;
            }
        }
    }

    public void LockOutfit(OutfitType type, string outfitName)
    {
        OutfitSection ot = outfits.FirstOrDefault(t => t.type == type);

        if (ot != null)
        {
            Outfit of = ot.outfits.FirstOrDefault(o => o.outfitName == outfitName);

            if (of != null)
            {
                of.isLocked = true;
            }

            CheckIfUsed(ot, of.idle);
        }
    }

    private void CheckIfUsed(OutfitSection section, Sprite sprite)
    {
        OutfitSwitcher outfitSwitcher = PlayerMovement.instance.gameObject.GetComponent<OutfitSwitcher>();

        switch (section.type)
        {
            case OutfitType.Clothes:
                if (outfitSwitcher.currentOutfit.clothes == sprite) outfitSwitcher.RestartType(section);
                break;
            case OutfitType.Hair:
                if (outfitSwitcher.currentOutfit.hair == sprite) outfitSwitcher.RestartType(section);
                break;
            case OutfitType.Hat:
                if (outfitSwitcher.currentOutfit.hat == sprite) outfitSwitcher.RestartType(section);
                break;
            default:
                break;
        }
    }
}

[System.Serializable]
public class Outfit
{
    public string outfitName;
    public RuntimeAnimatorController controller;
    public Sprite idle;
    public bool isLocked;
    public int price;
}

[System.Serializable]
public class OutfitSection
{
    public OutfitType type;
    public Animator animator;
    public Outfit[] outfits;
}

[System.Serializable]
public enum OutfitType
{
    Clothes,
    Hair,
    Hat
}