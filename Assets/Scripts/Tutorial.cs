using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private ConversationHandler conversationHandler;
    [SerializeField] private ConversationSO conversationSo;
    [SerializeField] private float hintDuration;
    private bool _hasShowed;
    private void Start()
    {
        _hasShowed = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagsAndLayers.PlayerTag) && !_hasShowed)
            StartCoroutine(ShowHint());
    }

    private IEnumerator ShowHint()
    {
        conversationHandler.SetDialogs(conversationSo.GetDialogs());
        conversationHandler.StartConversation(true);
        _hasShowed = true;
        yield return new WaitForSeconds(hintDuration);
        conversationHandler.QuitConversation();
    }
}
