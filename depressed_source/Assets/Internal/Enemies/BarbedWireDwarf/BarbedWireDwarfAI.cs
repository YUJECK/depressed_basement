using Internal.CodeBase.Enemies;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    [RequireComponent(typeof(BarbedWireDwarfAI))]
    public class BarbedWireDwarfAI : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        
        private NavMeshAgent agent;
        private TargetRadar radar;

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();

            agent.updateRotation = false;
            agent.updateUpAxis = false;
            
            radar = GetComponentInChildren<TargetRadar>();
        }

        private void Update()
        {
            if (radar.CurrentTarget != null)
            {
                agent.SetDestination(radar.CurrentTarget.transform.position);
                agent.isStopped = false;

                if (!spriteRenderer.flipX && radar.CurrentTarget.transform.position.x > transform.position.x)
                {
                    spriteRenderer.flipX = true;
                }
                if (spriteRenderer.flipX && radar.CurrentTarget.transform.position.x < transform.position.x)
                {
                    spriteRenderer.flipX = false;
                }
            }
        }
    }   
}
