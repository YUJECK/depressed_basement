using System.Collections;
using CodeBase.Helpers;
using Internal.CodeBase.Enemies;
using Internal.Enemies;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Flipper))]
public class KnifyDummyAI : Enemy
{
    [Header("Attack Setting")]
    [SerializeField] private Transform knifeSpawnPosition;
    [SerializeField] private GameObject knife;
    
    [Header("Local Components")]
    [SerializeField]private Animator animator;

    private NavMeshAgent agent;
    private TargetRadar radar;
    private Flipper flipper;

    private Coroutine runCoroutine;
    private Coroutine attackCoroutine;

    private void Start()
    {
        radar = GetComponentInChildren<TargetRadar>();
        agent = GetComponent<NavMeshAgent>();
        flipper = GetComponent<Flipper>();

        agent.updateRotation = false;
        agent.updateUpAxis = false;

        transform.rotation = Quaternion.Euler(0, 0, 0);
        
        StartRun();
    }

    private void StartRun()
    {
        runCoroutine = StartCoroutine(RunState());
    }

    private void StartAttack()
    {
        attackCoroutine = StartCoroutine(AttackState());
    }
    
    private IEnumerator RunState()
    {
        agent.enabled = true;
        agent.SetDestination(FightRoom.Area.GetRandomEmptyPoint());
        flipper.FlipTo(agent.destination);
        
        agent.isStopped = false;
        
        while (gameObject.activeSelf && agent.remainingDistance > agent.stoppingDistance)
        {
            yield return new WaitForEndOfFrame();
        }

        agent.enabled = false;
        runCoroutine = null;
        
        StartAttack();
    }
    
    private IEnumerator AttackState()
    {
        if (radar.CurrentTarget == null)
        {
            StartRun();
            yield return null;
        }
        
        flipper.FlipTo(radar.CurrentTarget.transform);

        var angle = AngleCalculator.GetAngle(knifeSpawnPosition.transform.position, radar.CurrentTarget.transform.position);
        
        animator.SetFloat("Angle", angle);
        animator.SetTrigger("Attack");
        
        Debug.Log(angle);
        
        yield return new WaitForSeconds(0.33f);

        var knifeInstance = FightRoom.Spawn(knife, knifeSpawnPosition.position);
        
        knifeInstance.transform.rotation = Quaternion.Euler(0, 0, angle);
        knifeInstance.GetComponent<KnifeWeapon>().AddForce();

        attackCoroutine = null;

        yield return new WaitForSeconds(0.3f);

        StartRun();
    }
}