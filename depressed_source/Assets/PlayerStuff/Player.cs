using CodeBase;
using UnityEngine;

namespace PlayerStuff
{
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerWeapon))]
    public class Player : DepressedBehaviour
    {
        public PlayerWeapon Weapon { get; private set; }
        public PlayerMovement Movement { get; private set; }
        public bool Stopped { get; set; } = false;

        private void Awake()
        {
            Weapon = GetComponent<PlayerWeapon>();
            Movement = GetComponent<PlayerMovement>();
        }
    }
}