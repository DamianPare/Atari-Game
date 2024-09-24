using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject gameScreen;
    public GameObject endScreen;
    public GameObject completedScreen;
    public Light2D playerLight;
    public GameObject[] uiTorches;
    public float maxFuel = 100f;
    public static GameManager instance;
    public float coalValue = 25f;
    public Image timerBar;

    private bool gameEnded;
    private int litTorches;
    private float currentFuel;
    public PlayerMovement playerController;

    void Start()
    {
        instance = this;
        Time.timeScale = 0f;
        currentFuel = maxFuel;
        ShowStartScreen();
        playerController.enabled = false;
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
            currentFuel -= Time.deltaTime;

            playerLight.pointLightOuterRadius = (currentFuel / 20);
            playerLight.intensity = (currentFuel / 50);

            if (currentFuel <= 0)
            {
                EndGame();
            }

            if (currentFuel > maxFuel)
            {
                currentFuel = maxFuel;
            }

            if (currentFuel > 0)
            {
                timerBar.fillAmount = currentFuel / maxFuel;
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
    }

    public void UpdateTorchCount()
    {
        uiTorches[litTorches].SetActive(true);
        litTorches += 1;
    }

    public void CollectedCoal()
    {
        if (coalValue + currentFuel > maxFuel)
        {
            currentFuel = maxFuel;
        }

        if (coalValue + currentFuel < maxFuel)
        {
            currentFuel += coalValue;
        }
        
    }

    public void AddTime()
    {
        currentFuel += 10f * Time.deltaTime;
    }
}
