using DefaultNamespace.MainGameplay;
using destructive_code;
using destructive_code.Scenes;
using destructive_code.Sounds;
using UnityEngine;
using Zenject;

namespace autumn_berries_mix
{
    public sealed class GameStartPoint: MonoBehaviour
    {
        public AudioPlayerPreset globalPreset;
        private DiContainer _container;

        [Inject]
        private void Construct(DiContainer container)
        {
            _container = container;
            
            _container.Inject(Resolver.Instance());
        }
        
        private void Start()
        {
            AudioPlayer.CreateGlobalFromPreset(globalPreset);
            SceneSwitcher.SwitchTo(new MainScene());
        }
    }
}