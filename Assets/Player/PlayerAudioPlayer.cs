using UnityEngine;

namespace Player
{
    public sealed class PlayerAudioPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource stepSource;
        
        public void PlaySteps()
        {
            stepSource.Play();
        }
        
        public void StopSteps()
        {
            stepSource.Stop();
        }
    }
}