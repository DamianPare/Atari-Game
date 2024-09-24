using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    [SerializeField] private GameObject LitPrefab;
    [SerializeField] private GameObject unLitPrefab;
    private bool torchCollected = false;
    public AudioClip pickupClip;
    public AudioSource audioSource;

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("collided");

        if (torchCollected == false)
        {
            audioSource.PlayOneShot(pickupClip);
            LitPrefab.SetActive(true);
            unLitPrefab.SetActive(false);
            GameManager.instance.UpdateTorchCount();
            torchCollected = true;
        }
    }
}
