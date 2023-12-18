using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;

    private void Start()
    {
        GameManager.instance.coinsUpdated += CoinsUpdatedHandler;
    }

    private void CoinsUpdatedHandler(int coins)
    {
        coinsText.text = coins.ToString();
    }
}
