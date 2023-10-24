using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class Cherry : MonoBehaviour, ICollectable
{
    [SerializeField] private int healthIncrease;
    [SerializeField] private Image cherryImage;
    private PlayerHealth _playerHealth;
    private int _collectedCherriesCount;
    void Start()
    {
        _playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagsAndLayers.PlayerTag))
        {
            _collectedCherriesCount++;
            cherryImage.gameObject.SetActive(true);
        }
    }


    public void Consume()
    {
        _playerHealth.IncreaseHealth(healthIncrease);
        _collectedCherriesCount--;
        if (_collectedCherriesCount == 0)
            cherryImage.gameObject.SetActive(false);
    }
}
