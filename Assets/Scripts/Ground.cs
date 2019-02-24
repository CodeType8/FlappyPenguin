using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MoveObject
{
    private Vector3 _startPosition = Vector3.zero;

    private void Awake()
    {
        _startPosition = transform.position;
    }

    override public void GameUpdate()
    {
        base.GameUpdate();
    }

    public void Init()
    {
        transform.position = _startPosition;
    }
}