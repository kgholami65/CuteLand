using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ConversationHandler : MonoBehaviour
{
    
    [SerializeField] private GameObject conversationCanvasPrefab;
    [SerializeField] private TextMeshProUGUI _conversationText;
    private int _currentDialogIndex;
    private List<string> _dialogs;
    private PlayerMovement _playerMovement;
    public bool _hasFinished;

    private void Start()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();
    }

    public void StartConversation()
    {
        _hasFinished = false;
        conversationCanvasPrefab.SetActive(true);
        _conversationText.text = _dialogs[0];
        _playerMovement.Disable();
    }

    public void DisplayNextConversation()
    {
        _currentDialogIndex++;
        
        if (_currentDialogIndex < _dialogs.Count)
            _conversationText.text = _dialogs[_currentDialogIndex];
        else
            QuitConversation();
    }

    public void QuitConversation()
    {
        _playerMovement.Enable();
        _currentDialogIndex = 0;
        conversationCanvasPrefab.SetActive(false);
        _hasFinished = true;

    }

    public void SetDialogs(List<string> dialogs)
    {
        _dialogs = dialogs;
    }
    

}
