using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleShop : MonoBehaviour
{
    [SerializeField] private GameObject shop;
    
    public void ShopState(bool state)
    {
        shop.SetActive(state);
        PlayerMovement.instance.canMove = !state;
    }
}
