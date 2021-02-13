using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private ColumnGenerator _generator;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;



    private void OnEnable()
    {
        _startScreen.PlayButtonClick += OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
        _bird.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClick -= OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
        _bird.GameOver -= OnGameOver;
    }

    private void Start()
    {
        _startScreen.Open();
        Time.timeScale = 0;
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        Time.timeScale = 1;
    }

    private void OnRestartButtonClick()
    {
        _gameOverScreen.Close();
        _bird.ResetBird();
        _generator.ResetPool();
        Time.timeScale = 1;
    }

    private void OnGameOver()
    {
        _gameOverScreen.Open();
        Time.timeScale = 0;
    }
}
