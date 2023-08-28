using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _step;
    [SerializeField] private float _maxHigh;
    [SerializeField] private float _minHigh;

    private Vector3 _targetPosition;
    private Coroutine _mover;

    private void Start()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        if (transform.position != _targetPosition)
        {
            StopMove();
            StartMove();
        }
    }

    public void TryMoveUp()
    {
        if (_targetPosition.y < _maxHigh && _targetPosition.y - transform.position.y <= 0)        
            SetTargetPosition(_step);        
    }

    public void TryMoveDown()
    {
        if (_targetPosition.y > _minHigh && _targetPosition.y - transform.position.y >= 0)        
            SetTargetPosition(-_step);        
    }

    private void SetTargetPosition(float step)
    {
        _targetPosition += Vector3.up * step;
    }

    private void StartMove()
    {
        _mover = StartCoroutine(Move());
    }

    private void StopMove()
    {
        if (_mover != null)
            StopCoroutine(_mover);
    }

    private IEnumerator Move()
    {
        while (transform.position != _targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
            yield return null;
        }

        transform.position = _targetPosition;
    }
}
