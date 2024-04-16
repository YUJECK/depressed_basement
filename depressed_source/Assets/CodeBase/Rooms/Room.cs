using Cinemachine;
using PlayerStuff;
using UnityEngine;

namespace CodeBase.Rooms
{
    public abstract class Room : MonoBehaviour
    {
        [field: SerializeField] public Transform StartPoint { get; private set; }
        [field: SerializeField] public string WalkSound { get; private set; }
        [field: SerializeField] public CinemachineVirtualCamera Camera { get; private set; }

        public abstract void OnEnter(Player player);

        public abstract void OnExit(Player player);
    }
}