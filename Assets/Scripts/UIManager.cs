using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _gameOverText;
    [SerializeField] private Text _gameWinText;

    [SerializeField] private string _scorePrefix = "Score: ";
    public int goodFishes
    {
        get { return _goodFishes; }

        set
        {
            _goodFishes = value;

            if (_goodFishes == 10)
            {
                GameWin();
            }
        }
    }
    private int _goodFishes;

    public int totalScore
    {
        get { return _totalScore; }

        set
        {
            _totalScore = value;

            if (_totalScore == -50)
            {
                GameOver();
            }
        }
    }
    private int _totalScore;

    private void Awake()
    {
        UpdateScore(0);
    }

    public void UpdateScore(int points)
    {
        totalScore += points;
        _scoreText.text = _scorePrefix + _totalScore;
    }

    private void GameOver()
    {
        _gameOverText.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void GameWin()
    {
        _gameWinText.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
