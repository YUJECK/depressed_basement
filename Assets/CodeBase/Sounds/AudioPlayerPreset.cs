using UnityEngine;

namespace destructive_code.Sounds
{
    [CreateAssetMenu(menuName = nameof(AudioPlayerPreset))]
    public class AudioPlayerPreset : ScriptableObject
    {
        public AudioData[] audios;
    }
}