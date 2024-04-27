using System;
using CodeBase.Hits;
using PlayerStuff;
using UnityEngine;

namespace FightRoomCode.Enemies.DummyChaser
{
    [RequireComponent(typeof(Collider2D))]
    public sealed class CollisionHit : MonoBehaviour
    {
        [SerializeField] private TouchHitData hitData;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.TryGetComponent(out PlayerHealth health))
                HitHandler.Hit(hitData, health);
        }
    }
}