using destructive_code.Scenes;
using Zenject;

namespace destructive_code.PrefabTags.CodeBase.Scenes
{
    public sealed class SceneSwitcherInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<SceneSwitcherTicker>()
                .AsSingle();
        }
    }
}