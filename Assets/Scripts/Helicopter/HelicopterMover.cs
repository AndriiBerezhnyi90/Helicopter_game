using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class HelicopterMover
{
    private Transform _transform;
    private Rigidbody _rigidbody;

    private float _moveSpeed;
    private float _rotationSpeed;
    private float _upSpeed;
    private float _currentHeight;
    private float _minHeight;
    private float _maxHeight;

    public bool IsUp { get; private set; }
    public float HeightCoefficient => _transform.localPosition.y / _maxHeight;

    public HelicopterMover(Transform transform,Rigidbody rigidbody, HelicopterParameters parameters)
    {
        _transform = transform;
        _rigidbody = rigidbody;
        _moveSpeed = parameters.MoveSpeed;
        _rotationSpeed = parameters.RotationSpeed;
        _upSpeed = parameters.UpSpeed;
        _currentHeight = _transform.localPosition.y;
        _minHeight = _transform.localPosition.y;
        _maxHeight = parameters.MaxHeight;
        IsUp = false;
    }

    public void Update(Vector2 moveDirection)
    {
        if (IsUp)
            Rotate(moveDirection);
    }

    public void FixedUpdate(Vector2 moveDirection)
    {
        ChangeHeight();

        if (IsUp)
            Move(moveDirection);
    }

    public void OnUp()
    {
        IsUp = true;
    }

    public void OnDown()
    {
        IsUp = false;
    }

    private void Move(Vector2 moveDirection)
    {
        if (moveDirection.y != 0)
        {
            Vector3 currentVelocity = _rigidbody.velocity;
            Vector3 forwardMove = _transform.forward * Time.fixedDeltaTime * _moveSpeed * moveDirection.y;
            _rigidbody.velocity += forwardMove;

            if (_rigidbody.velocity.magnitude > _moveSpeed)
                _rigidbody.velocity = currentVelocity;
        }
    }

    private void ChangeHeight()
    {
        if (IsUp)
        {
            float up = Math.Clamp(_transform.up.y * (1 - (_transform.position.y / _maxHeight)), 0, 1);
            Vector3 upVelocity = new Vector3(0, up * Time.fixedDeltaTime * _upSpeed, 0);

            if (_transform.localPosition.y < _maxHeight)
                _rigidbody.velocity += upVelocity;
        }
    }

    private void Rotate(Vector2 moveDirection)
    {
        _transform.Rotate(new Vector3(0, moveDirection.x * Time.deltaTime * _rotationSpeed, 0));
    }
}