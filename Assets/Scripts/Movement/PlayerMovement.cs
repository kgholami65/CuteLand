using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpSpeed;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private CapsuleCollider2D _capsuleCollider2D;
    private int _moveValue;
    private int _jumpValue;
    private bool _enable;
    private bool _isAlive;
    private void Awake()
    {
        _enable = true;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        _animator.SetBool("Jumping", false);
        _isAlive = true;
    }
    
    void Update()
    {
        if (_enable && _isAlive)
        {
            Move();
            Jump();
            StopJumpAnimation();
        }
    }

    public void SetMoveValue(int value)
    {
        _moveValue = value;
    }

    public void SetJumpValue(int value)
    {
        _jumpValue = value;
    }

    private void Move()
    {
        SetRunAnimation();
        _rigidbody2D.velocity = new Vector2(_moveValue * movementSpeed, _rigidbody2D.velocity.y);
        Rotate();
    }

    private void SetRunAnimation()
    {
        if (_moveValue != 0)
            _animator.SetBool("Running", true);
        else
            _animator.SetBool("Running", false);
    }

    private void Rotate()
    {
        if (_moveValue == 1 && transform.localScale.x != 1f)
            transform.localScale = new Vector3(_moveValue, 1, 0);
        else if (_moveValue == -1 && transform.localScale.x != -1f)
            transform.localScale = new Vector3(_moveValue, 1, 0);
    }

    private void Jump()
    {
        if (_capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask(TagsAndLayers.GroundLayer)) && _jumpValue != 0)
        {
            _animator.SetBool("Jumping", true);
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpSpeed * _jumpValue);
            _jumpValue = 0;
        }
    }

    private void StopJumpAnimation()
    {
        if (_rigidbody2D.velocity.y < 0  && _jumpValue == 0)
            _animator.SetBool("Jumping", false);
    }

    public void Disable()
    {
        _animator.SetBool("Jumping", false);
        _animator.SetBool("Running", false);
        _enable = false;
    }

    public void Enable()
    {
        _enable = true;
    }

    public void SetIsAlive(bool isAlive)
    {
        _isAlive = isAlive;
    }
}
