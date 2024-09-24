using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    public GameObject startScreen; // Assign in Inspector
    public GameObject gameScreen; // Assign in Inspector
    public GameObject endScreen;
    public GameObject completedScreen;
    public Light2D playerLight;
    public Text fuelText; // Assign in Inspector
    public GameObject[] uiTorches;
    public float maxFuel = 100f;
    public static GameManager instance;
    public float coalValue = 25f;

    private bool gameEnded;
    private int litTorches;
    private float currentFuel;
    public PlayerMovement playerController; // Reference to the player controller

    void Start()
    {
        instance = this;
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

            playerLight.pointLightOuterRadius = (currentFuel / 20);
            playerLight.intensity = (currentFuel / 50);

            if (currentFuel <= 0)
            {
                EndGame();
            }

            if (litTorches == 4)
            {
                CompletedGame();
            }
        }

        if (gameEnded == true && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
        endScreen.SetActive(true);
        playerController.enabled = false; // Disable player movement on game over
        gameEnded = true;
    }

    void CompletedGame()
    {
        Time.timeScale = 0f;
        gameScreen.SetActive(false);
        completedScreen.SetActive(true);
        playerController.enabled = false;
        gameEnded = true;
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

    public void UpdateTorchCount()
    {
        uiTorches[litTorches].SetActive(true);
        litTorches += 1;
    }

    public void AddTime()
    {
        currentFuel += coalValue;
    }
}
