using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleShop : MonoBehaviour
{
    [SerializeField] private GameObject shop;
    [SerializeField] private GameObject buyPage;
    [SerializeField] private GameObject sellPage;
    
    public void ShopState(bool state)
    {
        shop.SetActive(state);
        PlayerMovement.instance.canMove = !state;
        ChangePage(sellPage, buyPage);
    }

    private void ChangePage(GameObject disablePage, GameObject enablePage)
    {
        disablePage.SetActive(false);
        enablePage.SetActive(true);
    }

    public void OpenBuyPage()
    {
        ChangePage(sellPage, buyPage);
    }

    public void OpenSellPage()
    {
        ChangePage(buyPage, sellPage);
    }
}
