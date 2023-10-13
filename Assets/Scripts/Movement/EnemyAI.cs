using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float attackMovementSpeed;
    private GameObject _player;
    [SerializeField] private Sprite attackSprite;
    private bool _isDisabled;
    private Sprite _defaultSprite;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag(TagsAndLayers.PlayerTag);
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defaultSprite = _spriteRenderer.sprite;
        _isDisabled = false;
    }

    private void FollowPlayer()
    {
        Vector2 pos = Vector2.MoveTowards(transform.position,
            _player.transform.position, attackMovementSpeed * Time.deltaTime);
        _rigidbody2D.MovePosition(pos);
        transform.LookAt(pos);
        _spriteRenderer.sprite = attackSprite;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag(TagsAndLayers.PlayerTag) && !_isDisabled)
        {
            FollowPlayer();
            if (!_spriteRenderer.sprite.Equals(attackSprite))
                _spriteRenderer.sprite = attackSprite;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(TagsAndLayers.PlayerTag) && !_isDisabled)
            _spriteRenderer.sprite = _defaultSprite;
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
        _spriteRenderer.sprite = _defaultSprite;
        _isDisabled = true;
    }

    public bool GetIsDisabled()
    {
        return _isDisabled;
    }
}
