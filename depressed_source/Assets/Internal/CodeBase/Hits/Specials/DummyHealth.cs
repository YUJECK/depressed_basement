using destructive_code.Scenes;
using FightRoomCode;
using Internal.Enemies;
using UnityEngine;

namespace CodeBase.Hits
{
    public class DummyHealth : Health
    {
        private Animator _animator;
        private Enemy enemy;
        
        private void Start()
        {
            _animator = GetComponentInParent<Animator>();
            enemy = GetComponentInParent<Enemy>();
        }

        public override void GeneralHitProcessor(HitData data)
        {
            base.GeneralHitProcessor(data);
            
            Hits += data.Damage;            
            //_animator.SetTrigger("DummyHit");

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