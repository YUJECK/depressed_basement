using destructive_code.Sounds;
using UnityEngine;

namespace CodeBase.Hits
{
    public class HitSoundPlayer : MonoBehaviour
    {
        public string audioName;
        
        private Health _health;
        
        private void Start()
        {
            _health = GetComponent<Health>();
        }

        private void OnEnable() 
        {
            _health = GetComponent<Health>();
            _health.OnHit += OnHit;
        }

        private void OnDisable()
        {
            _health.OnHit -= OnHit;
        }

        private void OnHit()
        {
            AudioPlayer.Play(audioName);
        }
    }
}