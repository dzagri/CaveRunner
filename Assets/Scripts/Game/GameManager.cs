using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Variables
    public static GameManager instance;
    [HideInInspector] public int coins;
    [HideInInspector] public int currentCoins;
    [HideInInspector] public int heartAmount;
    [HideInInspector] public float currentScore;
    [HideInInspector] public float highScore;
    [HideInInspector] public float scoreSpeed;
    [HideInInspector] public float scoreMultiplier;
    [HideInInspector] public float platformSpeed = 10f;
    [HideInInspector] public bool playerDead;
    [HideInInspector] public bool playerDamage;
    [HideInInspector] public bool gameRestart;
    readonly float speedIncreaseInterval = 30f;
    readonly float scoreSpeedIncreaseAmount = 0.3f;
    float timeSinceLastIncrease = 0f;

    public event Action OnGameOver;
    public bool TryPurchase(int cost)
    {
        if(currentCoins >= cost)
        {
            currentCoins -= cost;
            PlayerPrefs.SetInt("Coins", currentCoins);
            PlayerPrefs.Save();
            return true;
        }
        else
        {
            return false;
        }
    }

    #endregion

    #region Life Cycle
    void Awake()
    {
        scoreSpeed = 0.4f;
        scoreMultiplier = 1.0f;
        currentCoins = PlayerPrefs.GetInt("Coins", 0);
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameStart()
    {
        currentState = GameState.running;
        playerDead = false;
        Time.timeScale = 1f;
        currentScore = 0;
        coins = 0;
        platformSpeed = 5;
        scoreSpeed = 0.4f;
    }

    void Update()
    {
        StateManager();
        AddScore();
    }

    #endregion 

    #region Logic
    void SpeedIncrease()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            timeSinceLastIncrease += Time.deltaTime;

            if (timeSinceLastIncrease >= speedIncreaseInterval)
            {
                platformSpeed += 2.5f;
                scoreSpeed += scoreSpeedIncreaseAmount;
                timeSinceLastIncrease = 0f;
            }
        }
        else
        {
            platformSpeed = 5;
        }
    }
    private void AddScore()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            currentScore += scoreSpeed * scoreMultiplier;

        }
        if (currentScore >= highScore)
        {
            highScore = currentScore;
        }

    }
    #endregion


    #region Game State
    private enum GameState
    {
        running,
        paused
    }
    private GameState currentState;
    void StateManager()
    {
        if (playerDead && currentState != GameState.paused)
        {
            currentState = GameState.paused;
            currentCoins += coins;
            PlayerPrefs.SetInt("Coins", currentCoins);
            PlayerPrefs.Save();
            OnGameOver?.Invoke();
        }
        else if (!playerDead)
        {
            currentState = GameState.running;
        }

        GameStates();
    }
    void GameStates()
    {
        switch (currentState)
        {
            case GameState.running:
                if (Time.timeScale != 1f) Time.timeScale = 1f;
                SpeedIncrease();
                break;
            case GameState.paused:
                if (Time.timeScale != 0f) Time.timeScale = 0f;
                break;
        }
    }
    #endregion

    #region Scene Management
    void OnEnable() => SceneManager.sceneLoaded += OnSceneLoaded;

    void OnDisable() => SceneManager.sceneLoaded -= OnSceneLoaded;
    void OnSceneLoaded(Scene scene, LoadSceneMode mode) => GameStart();
    #endregion
}
