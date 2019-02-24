using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedalRenderer : MonoBehaviour
{
    private int _value = 0;

    [SerializeField]
    private Image _image = null;

    [SerializeField]
    private Sprite[] _sprites = new Sprite[5];

    public int Value
    {
        get { return _value; }

        set
        {
            int rank = GetRank(value);
            _value = rank;
            Render();
        }
    }

    private void Render()
    {
        if (0 <= _value && _value < _sprites.Length)
        {
            _image.sprite = _sprites[_value];
        }
    }

    private int GetRank(int score)
    {
        if (20 < score)
        {
            return 4;
        }
        else if (15 < score)
        {
            return 3;
        }
        else if (10 < score)
        {
            return 2;
        }
        else if (5 < score)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}