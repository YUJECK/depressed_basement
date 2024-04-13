using System;
using System.Collections;
using CodeBase.Helpers;
using CodeBase.Hits;
using UnityEngine;

public class CombatDummy : MonoBehaviour
{
    private BulletHitData data = new BulletHitData();
    
    private TriggerHandler _trigger;
    private Animator _animator;

    private Coroutine _currentAttack;
    private HitOnTrigger _hitOnTrigger;
    
    private static readonly int AttackAnimTrigger = Animator.StringToHash("Attack");

    private void Start()
    {
        _trigger = GetComponentInChildren<TriggerHandler>();
        _hitOnTrigger = GetComponentInChildren<HitOnTrigger>();
        _animator = GetComponent<Animator>();
        
        _trigger.OnEnter += Attack;
    }

    private void OnDestroy()
    {
        _trigger.OnEnter -= Attack;
    }

    private void Attack(GameObject target)
    {
        if(_currentAttack != null)
            return;
        
        if (target.TryGetComponent(out Health health))
        {
            _currentAttack = StartCoroutine(AttackRoutine(health));
        }
    }

    private IEnumerator AttackRoutine(Health health)
    {
        _animator.SetTrigger(AttackAnimTrigger);

        yield return new WaitForSeconds(0.2f);

        _hitOnTrigger.Enabled = true;     
        
        yield return new WaitForSeconds(0.8f);

        _hitOnTrigger.Enabled = false;
        
        _currentAttack = null;
    }
}
