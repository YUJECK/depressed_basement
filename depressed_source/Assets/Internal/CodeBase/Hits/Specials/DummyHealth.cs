using System;
using destructive_code.Scenes;
using FightRoomCode;
using Internal.Enemies;
using UnityEngine;

namespace CodeBase.Hits
{
    public class DummyHealth : Health
    {
        [SerializeField] private GameObject deadDummy;
        [SerializeField] private Animator animator;
        
        private Enemy enemy;
        
        private void Start()
        {
            enemy = GetComponentInParent<Enemy>();
        }

        private void OnDestroy()
        {
            enemy.FightRoom.Spawn(deadDummy, transform.position);
        }

        public override void GeneralHitProcessor(HitData data)
        {
            base.GeneralHitProcessor(data);
            
            Hits += data.Damage;            
            animator.SetTrigger("DummyHit");

            if(Hits > 4)
            {
                SceneSwitcher.CurrentScene.Fabric.Destroy(enemy.gameObject);
            }
        }

        public override void TakeHitFromBlade(BladeHitData hitData)
        {
            GeneralHitProcessor(hitData);
        }
        
        public override void TakeHitFromBullet(BulletHitData hitData)
        {
            GeneralHitProcessor(hitData);
        }

        public override void TakeHitFromTouch(TouchHitData hitData)
        {
            GeneralHitProcessor(hitData);
        }
    }
}