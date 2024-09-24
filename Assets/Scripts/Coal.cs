using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;

public class CoalItem : MonoBehaviour
{
    [SerializeField] private GameObject coalPrefab;
    private bool coalCollected = false;
    public AudioClip pickupClip;
    public AudioSource audioSource;
    private bool inRange = false;
    public float pauseTimer;

    IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(pauseTimer);
        audioSource.PlayOneShot(pickupClip);
        coalPrefab.SetActive(false);
        GameManager.instance.CollectedCoal();
        coalCollected = true;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        inRange = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        inRange = false;
    }

    private void Update()
    {
        if (coalCollected == false && Input.GetKeyDown(KeyCode.Space) && inRange)
        {
            StartCoroutine(StartCountdown());
        }
    }
}
