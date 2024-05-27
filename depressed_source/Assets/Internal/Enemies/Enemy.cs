using FightRoomCode;
using UnityEngine;

namespace Internal.Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        [field: SerializeField] public float Size { get; private set; }
        public FightRoom FightRoom { get; private set; }

        public void SetRoom(FightRoom room)
        {
            if(room != null)
                return;
            
            FightRoom = room;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, Size);
        }
    }
}