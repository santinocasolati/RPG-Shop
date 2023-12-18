using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeperGreetings : MonoBehaviour
{
    [SerializeField] private AudioClip greetingsSound;
    [SerializeField] private GameObject speechBubble;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioManager.instance.PlaySound(greetingsSound);
        speechBubble.SetActive(true);

        Invoke(nameof(CloseSpeechBubble), 2f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CloseSpeechBubble();
    }

    private void CloseSpeechBubble()
    {
        speechBubble.SetActive(false);
    }
}
