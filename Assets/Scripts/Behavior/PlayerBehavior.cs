using System;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private Transform inventoryLocation;
    [SerializeField] private InventorySO inventorySo;
    private AudioPlayer _audioPlayer;

    private void Start()
    {
        _audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagsAndLayers.CollectableTag))
        {
            var collectable = other.GetComponent<ICollectable>();
            _audioPlayer.PlayCollectSound();
            inventorySo.Add(collectable);
            other.transform.position = inventoryLocation.position;
        }
    }

    public InventorySO GetInventory()
    {
        return inventorySo;
    }

    
}
