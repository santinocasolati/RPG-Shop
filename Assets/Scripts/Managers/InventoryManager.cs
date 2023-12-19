using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public OutfitType[] outfits;

    private void Awake()
    {
        instance = this;
    }

    public void UnlockOutfit(string type, string outfitName)
    {
        OutfitType ot = outfits.FirstOrDefault(t => t.name == type);

        if (ot != null)
        {
            Outfit of = ot.outfits.FirstOrDefault(o => o.outfitName == outfitName);

            if (of != null)
            {
                of.isLocked = false;
            }
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
}

[System.Serializable]
public class OutfitType
{
    public string name;
    public Animator animator;
    public Outfit[] outfits;
}