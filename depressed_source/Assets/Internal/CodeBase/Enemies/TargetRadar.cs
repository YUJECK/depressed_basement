using System;
using UnityEngine;

namespace Internal.CodeBase.Enemies
{
    [RequireComponent(typeof(Collider2D))]
    public sealed class TargetRadar : MonoBehaviour
    {
        public EnemyTarget CurrentTarget;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out EnemyTarget target))
            {
                if (CurrentTarget != null && CurrentTarget.Priority < target.Priority)
                    CurrentTarget = target;
                else if (CurrentTarget == null)
                    CurrentTarget = target;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject == CurrentTarget.gameObject)
                CurrentTarget = null;
        }
    }
}