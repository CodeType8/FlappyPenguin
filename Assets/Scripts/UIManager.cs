using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField]
    private GameObject _title = null;

    [SerializeField]
    private GameObject _newBestScore = null;

    [SerializeField]
    private Button _startButton = null;

    [SerializeField]
    private Button _tipButton = null;

    [SerializeField]
    private NumbersRenderer _score = null;

    [SerializeField]
    private GameOverPopup _gameOverPopup = null;

    public int Score
    {
        set
        {
            _newBestScore.SetActive(Manager.Instance.isCurrentBestScore);
            _score.Value = value;
        }
    }

    public void Init()
    {
        _title.SetActive(false);
        _newBestScore.SetActive(false);
        _startButton.gameObject.SetActive(false);
        _tipButton.gameObject.SetActive(false);
        _score.gameObject.SetActive(false);
        _gameOverPopup.gameObject.SetActive(false);
    }

    public void ShowTitle()
    {
        _title.gameObject.SetActive(true);
        _startButton.gameObject.SetActive(true);
    }

    public void StartButton()
    {
        ShowTipButton();

        _title.SetActive(false);
        _startButton.gameObject.SetActive(false);
    }

    public void TipButton()
    {
        ShowScore();
        Manager.Instance.isPlay = true;
        _tipButton.gameObject.SetActive(false);
    }

    private void ShowTipButton()
    {
        _tipButton.gameObject.SetActive(true);
    }

    public void ShowScore()
    {
        _score.Value = 0;
        _score.gameObject.SetActive(true);
        _newBestScore.SetActive(false);
    }

    public void InvokeGameOver()
    {
        _gameOverPopup.Show();
        _score.gameObject.SetActive(false);
        _newBestScore.SetActive(false);
    }
}