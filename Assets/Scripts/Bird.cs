using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MoveObject
{
    [SerializeField]
    private Rigidbody2D _rigiBody = null;
    [SerializeField]
    private float _jumpvalue = 1.0f;
    [SerializeField]
    private float _birdJumpTime = 0.1f;
    private float _birdCurrentTime = 0.0f;

    private bool _check = false;

    override public void GameUpdate()
    {
        base.GameUpdate();

        _birdCurrentTime += Time.deltaTime;
        if (_birdJumpTime < _birdCurrentTime)
        {
            _birdCurrentTime = 0;

            _rigiBody.AddForce(new Vector2(0, _jumpvalue));
        }
    }

    override protected void FinishEndPosition()
    {
        Manager.Instance.Remove2(this);
    }

    public bool isNeedInvokeScoreCheck(Vector3 target)
    {
        if (!_check)
        {
            if (transform.position.x <= target.x)
            {
                _check = true;
                return true;
            }
        }
        return false;
    }
}
