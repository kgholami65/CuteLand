using System;
using System.Collections;
using UnityEngine;

public class EnemyDamageDealer : DamageDealer
{
    [SerializeField] private float resetDelay;
    private EnemyAI _enemyAI;

    private void Start()
    {
        _enemyAI = GetComponent<EnemyAI>();
    }

    public override void Hit()
    {
        if (!_enemyAI.GetIsDisabled())
            StartCoroutine(ResetAI());
    }
    
    private IEnumerator ResetAI()
    {
        _enemyAI.Disable();
        yield return new WaitForSecondsRealtime(resetDelay);
        _enemyAI.Enable();
    }

    
}
