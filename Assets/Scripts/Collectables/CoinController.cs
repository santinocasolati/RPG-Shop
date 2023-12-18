using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private AudioClip coinAudio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameManager.instance.AddCoins(1);
            AudioManager.instance.PlaySound(coinAudio);
            Destroy(gameObject);
        }
    }
}
