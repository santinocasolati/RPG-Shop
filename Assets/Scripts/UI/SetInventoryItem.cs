using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetInventoryItem : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Image border;

    public void ChangeItem(Sprite sprite)
    {
        image.sprite = sprite;
        image.gameObject.SetActive(true);
    }
}
