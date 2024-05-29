using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Internal.CodeBase.GameObjects
{
    public abstract class DestroyDelay : MonoBehaviour
    {
        public abstract UniTask Destroy();
    }
}