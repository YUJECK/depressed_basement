using UnityEngine;

namespace CodeBase.CursorLogic
{
    [CreateAssetMenu(menuName = "Configs/CursorConfig")]
    public class CursorConfig : ScriptableObject
    {
        [field: SerializeField] public CursorState Default { get; private set; }
        [field: SerializeField] public CursorState Fight { get; private set; }
        [field: SerializeField] public CursorState Interaction { get; private set; }
    }
}