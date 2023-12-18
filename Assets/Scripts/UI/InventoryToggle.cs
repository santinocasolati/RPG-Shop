using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    public float zoomDuration = 0.5f;

    [SerializeField] private GameObject[] hideIcons;
    [SerializeField] private GameObject inventoryPage;
    [SerializeField] private AudioClip openAudio;
    [SerializeField] private AudioClip closeAudio;

    public void ToggleInventory(bool state)
    {
        foreach (GameObject icon in hideIcons)
        {
            icon.SetActive(!state);
        }

        inventoryPage.SetActive(state);
        PlayerMovement.instance.canMove = !state;

        AudioClip audio = closeAudio;

        if (state)
        {
            audio = openAudio;
        }

        AudioManager.instance.PlaySound(audio);

        float targetZoom = state ? 2.5f : 5f;

        StartCoroutine(AnimateZoom(targetZoom));
    }

    private IEnumerator AnimateZoom(float zoom)
    {
        float elapsedTime = 0;
        float startSize = Camera.main.orthographicSize;

        while (elapsedTime < zoomDuration)
        {
            Camera.main.orthographicSize = Mathf.Lerp(startSize, zoom, elapsedTime / zoomDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Camera.main.orthographicSize = zoom;
    }
}
