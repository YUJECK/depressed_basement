using UnityEngine;

namespace Internal.Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        [field: SerializeField] public float Size { get; private set; }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, Size);
        }
    }
}