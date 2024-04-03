using CodeBase;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerItemEquiper))]
    public class Player : DepressedBehaviour
    {
        public PlayerItemEquiper Equiper { get; private set; }

        private void Awake()
        {
            Equiper = GetComponent<PlayerItemEquiper>();
        }
    }
}