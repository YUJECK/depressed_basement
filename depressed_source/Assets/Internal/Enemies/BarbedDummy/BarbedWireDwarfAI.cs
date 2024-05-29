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
        
        private NavMeshAgent agent;
        private TargetRadar radar;

        public override void WillBeDestroyed()
        {
            agent.enabled = false;
        }

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();

            agent.updateRotation = false;
            agent.updateUpAxis = false;
            
            radar = GetComponentInChildren<TargetRadar>();
        }

        private void Update()
        {
            if (agent.enabled && radar.CurrentTarget != null)
            {
                agent.SetDestination(radar.CurrentTarget.transform.position);
                agent.isStopped = false;

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
    }   
}
