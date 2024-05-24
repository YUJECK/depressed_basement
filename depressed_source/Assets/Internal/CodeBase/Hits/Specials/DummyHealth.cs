using UnityEngine;

namespace CodeBase.Hits
{
    public class DummyHealth : Health
    {
        [SerializeField] private SpriteRenderer plushSprite;
        [SerializeField] private AudioSource ripped;
        private Animator _animator;
        
        private void Start()
        {
            _animator = GetComponentInParent<Animator>();
        }
        
        public override void TakeHitFromBlade(BladeHitData hitData)
        {
            Hits++;
            
            _animator.SetTrigger("DummyHit");

            if (Hits > 3)
            {
                plushSprite.gameObject.SetActive(true);
                ripped.Play();
            }
                
        }
        
        public override void TakeHitFromBullet(BulletHitData hitData)
        {
            Hits++;
            
            _animator.SetTrigger("DummyHit");
        }

        public override void TakeHitFromTouch(TouchHitData hitData)
        {
            
        }
    }
}