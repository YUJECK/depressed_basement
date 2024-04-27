using UnityEngine;

namespace Internal.CodeBase
{
    public class EnemyTarget : MonoBehaviour
    {
        [field: SerializeField] public int Priority { get; private set; }
    }
}