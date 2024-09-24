using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalItem : MonoBehaviour
{
    [SerializeField] private GameObject coalPrefab;
    private bool coalCollected = false;
    public AudioClip pickupClip;
    public AudioSource audioSource;

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("collided");

        if (coalCollected == false)
        {
            audioSource.PlayOneShot(pickupClip);
            coalPrefab.SetActive(false);
            GameManager.instance.AddTime();
            coalCollected = true;
        }
    }
}
