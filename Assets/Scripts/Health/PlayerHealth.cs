
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{

    [SerializeField] private float throwBackSpeed;
    [SerializeField] private Slider healthBar;
    [SerializeField] private Sprite deathSprite;
    [SerializeField] private float deathDelay;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private GameManager _gameManager;
    private Animator _animator;
    private AudioPlayer _audioPlayer;
    private PlayerMovement _playerMovement;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        healthBar.maxValue = health;
        healthBar.value = health;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _gameManager = FindObjectOfType<GameManager>();
        _animator = GetComponent<Animator>();
        _audioPlayer = FindObjectOfType<AudioPlayer>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    public override void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.value = health;
        if (health <= 0)
            Die();
    }

    private void Die()
    {
        _spriteRenderer.sprite = deathSprite;
        transform.Rotate(0, 0, 90);
        _animator.enabled = false;
        _playerMovement.SetIsAlive(false);
        StartCoroutine(Lose());
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag(TagsAndLayers.EnemyTag))
        {
            if (other.collider.GetComponent<EnemyAI>() == null || !other.collider.GetComponent<EnemyAI>().GetIsDisabled())
            {
                
                _rigidbody2D.velocity = new Vector2(throwBackSpeed,
                    10);
                var damageDealer = other.collider.GetComponent<DamageDealer>();
                damageDealer.Hit();
                _audioPlayer.PlayPlayerHitSound();
                TakeDamage(damageDealer.GetDamage());
            }
        }
        else if (other.collider.CompareTag(TagsAndLayers.HazardTag))
        {
            _audioPlayer.PlayPlayerHitSound();
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagsAndLayers.WaterTag))
            Die();
    }

    private IEnumerator Lose()
    {
        yield return new WaitForSeconds(deathDelay);
        _gameManager.Lose();
    }

    public int GetHealth()
    {
        return health;
    }

    public void IncreaseHealth(int healthIncrease)
    {
        int newHealth = healthIncrease + health;
        if (newHealth > healthBar.maxValue)
            health = (int) healthBar.maxValue;
        else
            health = newHealth;
        healthBar.value = health;
    }
}
