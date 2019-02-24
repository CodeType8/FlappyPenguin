using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice: MoveObject
{
    [SerializeField]
    private GameObject _topIce = null;

    private float _defalutTopPositionY = 0.0f;
    private float _defalutBasePositionY = 0.0f;

    private bool _pgCheck = false;

    private void Start()
    {
        _defalutTopPositionY = _topIce.transform.localPosition.y;
        _defalutBasePositionY = transform.position.y;
    }

    override public void GameUpdate()
    {
        base.GameUpdate();
    }

    override protected void FinishEndPosition()
    {
        Manager.Instance.Remove(this);
    }

    public void SetHeight(float value)
    {
        Vector3 result = _topIce.transform.localPosition;
        result.y = value + _defalutTopPositionY;

        _topIce.transform.localPosition = result;
    }

    public void SetPositionY(float value)
    {
        Vector3 result = transform.position;
        result.y = value + _defalutBasePositionY;

        transform.position = result;
    }

    public bool isNeedInvokeScoreCheck(Vector3 target)
    {
        if (!_pgCheck)
        {
            if (transform.position.x <= target.x)
            {
                _pgCheck = true;
                return true;
            }
        }
        return false;
    }
}