using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private ConversationHandler conversationHandler;
    [SerializeField] private ConversationSO conversationSo;
    private bool _hasShowed;
    private void Start()
    {
        _hasShowed = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagsAndLayers.PlayerTag) && !_hasShowed)
        {
            conversationHandler.SetDialogs(conversationSo.GetDialogs());
            conversationHandler.StartConversation();
            _hasShowed = true;
        }
    }
}
