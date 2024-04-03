using Zenject;

namespace destructive_code.Scenes
{
    public sealed class SceneSwitcherTicker : ITickable
    {
        public void Tick()
            => SceneSwitcher.Tick();
    }
}