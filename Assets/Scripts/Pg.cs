using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pg : MonoBehaviour, IGameObject
{
    [SerializeField]
    private Rigidbody2D _rigidbody = null;

    [SerializeField]
    private float _jumpValue = 1.0f;

    private Vector3 _startPosition = Vector3.zero;
    private Quaternion _startRotation = Quaternion.identity;

    private void Awake()
    {
        _startPosition = transform.position;
        _startRotation = transform.rotation;
    }

    public void Init()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;
    }

    private void Start()
    {
        _rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    public void GameUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _rigidbody.AddForce(new Vector2(0, _jumpValue));
        }
    }

    public void FreezePositionY(bool value)
    {
        _rigidbody.constraints = value ? RigidbodyConstraints2D.FreezePositionY : RigidbodyConstraints2D.None;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log( collision.gameObject.tag );
        switch (collision.gameObject.tag)
        {
            case "Enemy":
                Manager.Instance.isPlay = false;
                break;
        }
    }
}