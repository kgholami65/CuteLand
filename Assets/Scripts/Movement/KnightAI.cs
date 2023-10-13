using System;
using UnityEngine;

public class KnightAI : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float attackMovementSpeed;
    private GameObject _player;
    private bool _isDisabled;
    private Animator _animator;
    private bool _isAttacking;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag(TagsAndLayers.PlayerTag);
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _isDisabled = false;
        _animator = GetComponent<Animator>();
    }
    

    private void FollowPlayer()
    {
        if (!_isAttacking)
        {
            Vector2 pos = Vector2.MoveTowards(transform.position,
                _player.transform.position, attackMovementSpeed * Time.deltaTime);
            _rigidbody2D.MovePosition(pos);
            if (transform.position.x > _player.transform.position.x && transform.localScale.x == 1)
                transform.localScale = new Vector3(-1, 1, 0);
            else if (transform.position.x < _player.transform.position.x && transform.localScale.x == -1)
                transform.localScale = new Vector3(1, 1, 0);
            _animator.SetBool("isWalking", true);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag(TagsAndLayers.PlayerTag) && !_isDisabled)
        {
            FollowPlayer();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(TagsAndLayers.PlayerTag) && !_isDisabled)
        {
            _animator.SetBool("isWalking", false);
        }
    }

    public void SetIsDisabled(bool value)
    {
        _isDisabled = value;
        
    }

    public void Enable()
    {
        _isDisabled = false;
    }

    public void Disable()
    {
        _isDisabled = true;
    }

    public bool GetIsDisabled()
    {
        return _isDisabled;
    }
}
