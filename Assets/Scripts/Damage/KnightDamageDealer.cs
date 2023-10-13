using System;
using System.Collections;
using UnityEngine;

public class KnightDamageDealer : DamageDealer
{
    [SerializeField] private float resetDelay;
    private KnightAI _knightAI;

    private void Start()
    {
        _knightAI = GetComponent<KnightAI>();
    }

    public override void Hit()
    {
        if (!_knightAI.GetIsDisabled())
            StartCoroutine(ResetAI());
    }
    
    private IEnumerator ResetAI()
    {
        _knightAI.Disable();
        yield return new WaitForSecondsRealtime(resetDelay);
        _knightAI.Enable();
    }

    
}
