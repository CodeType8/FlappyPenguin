using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPopup : MonoBehaviour
{
    [SerializeField]
    private MedalRenderer _medalRenderer = null;

    [SerializeField]
    private NumbersRenderer _score = null;
    [SerializeField]
    private NumbersRenderer _best = null;

    [SerializeField]
    private GameObject _newBestScore = null;

    public void Show()
    {
        gameObject.SetActive(true);

        _newBestScore.SetActive(Manager.Instance.isCurrentBestScore);
        _medalRenderer.Value = Manager.Instance.Score;
        _score.Value = Manager.Instance.Score;
        _best.Value = Manager.Instance.BestScore;
    }

    public void OkButton()
    {
        gameObject.SetActive(false);
        Manager.Instance.Replay();
    }
}