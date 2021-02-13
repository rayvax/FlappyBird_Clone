using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class BirdMovement : MonoBehaviour
{
    [SerializeField] private Vector2 _startingPosition;
    [SerializeField] private float _tapForce;
    [Space]
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);

        ResetMovement();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Jump();
            transform.rotation = _maxRotation;
            _animator.SetTrigger("Fly");
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.AddForce(Vector2.up * _tapForce);
    }

    public void ResetMovement()
    {
        transform.position = _startingPosition;
        _rigidbody.velocity = Vector2.zero;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
