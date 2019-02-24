using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Manager : Singleton<Manager>
{
    [SerializeField]
    private Pg _pg = null;
    [SerializeField]
    private Ground _ground = null;
    [SerializeField]
    private Ice _ice = null;
    [SerializeField]
    private Bird _bird = null;

    [SerializeField]
    private float _speed = 0.001f;
    
    [SerializeField]
    private float _iceCreateTime = 1.0f;
    //[SerializeField]
    private float _iceCurrentTime = 0.0f;
    [SerializeField]
    private float _iceRandomHeight = 0.4f;
    [SerializeField]
    private float _iceRandomPositionY = 0.5f;
    [SerializeField]
    private float _birdCreateTime = 5.8f;
    //[SerializeField]
    private float _birdCurrentTime = 0.0f;

    private List<Ice> _iceList = new List<Ice>();
    private List<Bird> _birdList = new List<Bird>();

    private bool _pgPlay = false;
    private bool _pgCurrentBestScore = false;
    private int _score = 0;
    private int _bestScore = 0;

    public int Score { get { return _score; } }
    public int BestScore { get { return _bestScore; } }
    public bool isCurrentBestScore { get { return _pgCurrentBestScore; } }

    public float Speed { get { return _speed; } }
    public bool isPlay
    {
        get { return _pgPlay; }
        set
        {
            _pgPlay = value;
            if (!_pgPlay)
            {
                UIManager.Instance.InvokeGameOver();
            }
        }
    }

    private void Start()
    {
        Init();
        UIManager.Instance.ShowTitle();
        _bestScore = PlayerPrefs.GetInt("_bestScore");
    }

    private void Init()
    {
        _pgCurrentBestScore = false;
        _pgPlay = false;
        _score = 0;
        _iceCurrentTime = 0.0f;
        _birdCurrentTime = 0.0f;
        _pg.Init();
        _ground.Init();
        _iceList.ToArray().ToList().ForEach(x => Remove(x));
        _birdList.ToArray().ToList().ForEach(x => Remove2(x));

        UIManager.Instance.Init();
    }

    public void Replay()
    {
        Debug.Log("Replay");
        Init();
        UIManager.Instance.ShowScore();
        _pgPlay = true;
    }

    void Update()
    {
        _pg.FreezePositionY(!_pgPlay);
        if (_pgPlay)
        {
            _iceCurrentTime += Time.deltaTime;
            if (_iceCreateTime < _iceCurrentTime)
            {
                _iceCurrentTime = 0;

                _ice.SetHeight(Random.Range(0.0f, _iceRandomHeight));
                _ice.SetPositionY(Random.Range(0.0f, _iceRandomPositionY));
                _iceList.Add(GameObject.Instantiate(_ice));
            }

            _birdCurrentTime += Time.deltaTime;
            if (_birdCreateTime < _birdCurrentTime)
            {
                _birdCurrentTime = 0;
                _birdList.Add(GameObject.Instantiate(_bird));
            }

                _pg.GameUpdate();
            _ground.GameUpdate();
            _iceList.ForEach((x) =>
            {
                x.GameUpdate();
                if (x.isNeedInvokeScoreCheck(_pg.transform.position))
                {
                    InvokeScore();
                }
            });
            _birdList.ForEach((x) =>
            {
                x.GameUpdate();
                if (x.isNeedInvokeScoreCheck(_pg.transform.position))
                {
                    InvokeScore();
                }
            });
        }
    }

    public void Remove(Ice target)
    {
        _iceList.Remove(target);
        Debug.Log(target.gameObject.name + " / " + _iceList.Count);
        DestroyImmediate(target.gameObject);
    }

    public void Remove2(Bird target)
    {
        _birdList.Remove(target);
        Debug.Log(target.gameObject.name + " / " + _birdList.Count);
        DestroyImmediate(target.gameObject);
    }

    private void InvokeScore()
    {
        _score++;

        if (_bestScore < _score)
        {
            _pgCurrentBestScore = true;
            _bestScore = _score;

            PlayerPrefs.SetInt("_bestScore", _bestScore);
            PlayerPrefs.Save();
        }

        UIManager.Instance.Score = _score;
    }
}