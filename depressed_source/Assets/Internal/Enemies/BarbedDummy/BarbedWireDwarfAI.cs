using System.Collections;
using Internal.CodeBase.Enemies;
using Internal.Enemies;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    [RequireComponent(typeof(BarbedWireDwarfAI))]
    public class BarbedWireDwarfAI : Enemy
    {
        [SerializeField] private SpriteRenderer spriteRenderer; 
        
        private Animator animator;
        private TargetRadar radar;

        private Coroutine runCoroutine;
        private Coroutine waitCoroutine;

        public override void WillBeDestroyed()
        {
            if(runCoroutine != null) 
                StopCoroutine(runCoroutine);
            if(waitCoroutine != null)
                StopCoroutine(waitCoroutine);
        }

        private void Start()
        {
            radar = GetComponentInChildren<TargetRadar>();
            animator = GetComponentInChildren<Animator>();
        }

        private void Update()
        {
            if (radar.CurrentTarget != null)
            {
                if (runCoroutine == null && waitCoroutine == null)
                    StartRun();
                
                if (!spriteRenderer.flipX && radar.CurrentTarget.transform.position.x < transform.position.x)
                {
                    spriteRenderer.flipX = true;
                }
                if (spriteRenderer.flipX && radar.CurrentTarget.transform.position.x > transform.position.x)
                {
                    spriteRenderer.flipX = false;
                }
            }
        }

        private void StartRun()
        {
            if(runCoroutine == null && waitCoroutine == null)
                runCoroutine = StartCoroutine(RunState());
            
            animator.SetBool("Run", true);
        }

        private void StartWait()
        {
            if(runCoroutine == null && waitCoroutine == null)
                waitCoroutine = StartCoroutine(WaitState());
            
            animator.SetBool("Run", false);
        }

        private IEnumerator RunState()
        {
            Vector3 destination = radar.CurrentTarget.transform.position;
            float speed = 7;
            
            while (Vector3.Distance(transform.position, destination) > 0.5)
            {
                transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * speed);
                yield return new WaitForFixedUpdate();
                speed = speed / (speed * 2) * 10;
            }

            runCoroutine = null;
            StartWait();
        }

        private IEnumerator WaitState()
        {
            yield return new WaitForSeconds(2f);
            
            while (radar.CurrentTarget == null)
            {
                yield return new WaitForEndOfFrame();
            }
        
            waitCoroutine = null;
            StartRun();
        }
    }   
}
