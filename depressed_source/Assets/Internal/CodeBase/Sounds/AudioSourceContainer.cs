using System;
using UnityEngine;

namespace destructive_code
{
    public sealed class AudioSourceContainer : MonoBehaviour
    {
        [SerializeField] private PitchedAudioMonoBehaviour[] audios;
        
        private void Reset()
        {
            audios = GetComponentsInChildren<PitchedAudioMonoBehaviour>();
        }

        public void Play0()
        {
            audios[0].Play();
        }
        
        public void Play1()
        {
            audios[1].Play();
        }
        
        public void Play2()
        {
            audios[2].Play();
        }
        
        public void Play3()
        {
            audios[3].Play();
        }
        
        public void Play4()
        {
            audios[4].Play();
        }
        
        public void Play5()
        {
            audios[5].Play();
        }
    }   
}
