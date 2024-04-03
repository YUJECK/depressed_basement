using destructive_code.Sounds;
using UnityEngine;

namespace DefaultNamespace
{
    public sealed class AudioPlayerPresetLoader : MonoBehaviour
    {
        [SerializeField] private AudioPlayerPreset preset;
        
        private void Awake()
        {
            AudioPlayer.CreateGlobalFromPreset(preset);
        }
    }
}