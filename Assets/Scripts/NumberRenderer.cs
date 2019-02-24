using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberRenderer : MonoBehaviour
{
    //[SerializeField]
    [Range(0, 9)]
    private int _value = 0;

    [SerializeField]
    private Image _image = null;

    [SerializeField]
    private Sprite[] _sprites = new Sprite[10];

    public int Value
    {
        get { return _value; }

        set
        {
            _value = value;
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
}