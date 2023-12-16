using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OutfitSwitcher : MonoBehaviour
{
    public OutfitType[] outfitTypes;

    public void A()
    {
        ChangeOutfit("Clothes", "Cloth1");
    }

    public void ChangeOutfit(string type, string name)
    {
        OutfitType ot = outfitTypes.FirstOrDefault(t => t.name == type);

        if (ot != null)
        {
            Outfit of = ot.outfits.FirstOrDefault(o => o.outfitName == name);

            if (of != null)
            {
                ot.animator.gameObject.GetComponent<SpriteRenderer>().sprite = of.idle;
                ot.animator.runtimeAnimatorController = of.controller;
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
}

[System.Serializable]
public class OutfitType
{
    public string name;
    public Animator animator;
    public Outfit[] outfits;
}
