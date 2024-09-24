using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Torch : MonoBehaviour
{
    [SerializeField] private GameObject LitPrefab;
    private bool torchCollected = false;
    public AudioClip pickupClip;
    public AudioSource audioSource;
    private bool inRange = false;
    public float pauseTimer;

    IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(pauseTimer);
        GameManager.instance.UpdateTorchCount();
        audioSource.PlayOneShot(pickupClip);
        LitPrefab.SetActive(true);
        torchCollected = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (torchCollected == true)
        {
            GameManager.instance.AddTime();
        }
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
        if (torchCollected == false && Input.GetKeyDown(KeyCode.Space) && inRange == true)
        {
            StartCoroutine(StartCountdown());
        }
    }
}
