using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DefaultNamespace;
using UnityEngine;

public class PenguinBehavior : MonoBehaviour
{
    [SerializeField] private ConversationSO firstConversationSo;
    [SerializeField] private ConversationSO secondConversationSo;
    [SerializeField] private List<GameObject> requirements;
    [SerializeField] private float winDelay;
    private InventorySO _playerInventory;
    private ConversationHandler _conversationHandler;
    private List<ICollectable> _requiredCollectables;
    private GameManager _gameManager;
    private AudioPlayer _audioPlayer;
    private PenguinPathFinder _penguinPathFinder;
    private void Start()
    {
        _conversationHandler = FindObjectOfType<ConversationHandler>();
        _gameManager = FindObjectOfType<GameManager>();
        _audioPlayer = FindObjectOfType<AudioPlayer>();
        _requiredCollectables = new List<ICollectable>();
        _penguinPathFinder = GetComponent<PenguinPathFinder>();
        foreach (var elements in requirements)
            _requiredCollectables.Add(elements.GetComponent<ICollectable>());
    }

    private void Update()
    {
        if (_conversationHandler._hasFinished && !_penguinPathFinder.enable)
            _penguinPathFinder.Enable();

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagsAndLayers.PlayerTag))
        {
            _playerInventory = other.GetComponent<PlayerBehavior>().GetInventory();
            if (!CheckPlayerInventory())
            {
                _penguinPathFinder.Disable();
                _conversationHandler.SetDialogs(firstConversationSo.GetDialogs());
                _conversationHandler.StartConversation();
            }
            else
            {
                _conversationHandler.SetDialogs(secondConversationSo.GetDialogs());
                ConsumeItems();
                _conversationHandler.StartConversation();
                _penguinPathFinder.Disable();
                StartCoroutine(WinPlayer());
            }
        }
    }

    public bool CheckPlayerInventory()
    {
        return !_requiredCollectables.Except(_playerInventory.GetCollectables()).Any();
    }

    public void ConsumeItems()
    {
        foreach (var requiredCollectable in _requiredCollectables)
            requiredCollectable.Consume();
    }

    private IEnumerator WinPlayer()
    {
        _audioPlayer.PlayQuestCompleteSound();
        yield return new WaitForSeconds(winDelay);
        _gameManager.Win();
    }
}
