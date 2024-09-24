using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject startScreen; // Assign in Inspector
    public GameObject gameScreen; // Assign in Inspector
    public Text fuelText; // Assign in Inspector
    public float maxFuel = 100f;

    private float currentFuel;
    public PlayerMovement playerController; // Reference to the player controller

    void Start()
    {
        Time.timeScale = 0f;
        currentFuel = maxFuel;
        ShowStartScreen();
        playerController.enabled = false; // Disable player movement at start
    }

    void Update()
    {
        if (startScreen.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartGame();
            }
        }
        else if (gameScreen.activeSelf)
        {
            currentFuel -= Time.deltaTime; // Decrease fuel over time
            UpdateFuelUI();

            if (currentFuel <= 0)
            {
                EndGame();
            }
        }
    }

    void StartGame()
    {
        Time.timeScale = 1f;
        startScreen.SetActive(false);
        gameScreen.SetActive(true);
        currentFuel = maxFuel; // Reset fuel for new game
        playerController.enabled = true; // Enable player movement
    }

    void EndGame()
    {
        gameScreen.SetActive(false);
        ShowStartScreen();
        playerController.enabled = false; // Disable player movement on game over
    }

    void ShowStartScreen()
    {
        startScreen.SetActive(true);
        gameScreen.SetActive(false);
        UpdateFuelUI();
    }

    void UpdateFuelUI()
    {
        fuelText.text = "Fuel: " + Mathf.Max(currentFuel, 0).ToString("F2");
    }
}
