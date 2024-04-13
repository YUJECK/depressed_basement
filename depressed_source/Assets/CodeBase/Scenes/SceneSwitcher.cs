using System;
using Internal.Codebase.Infrastructure.Services.SceneLoader;    

namespace destructive_code.Scenes
{
    public static class SceneSwitcher
    {
        public static Scene CurrentScene { get; private set; }
 
        public static event Action<Scene> OnSceneStartedLoading; //prev
        public static event Action<Scene, Scene> OnSceneLoaded; //prev/new

        private static readonly AsyncSceneLoader Loader = new();
        
        public static void SwitchTo<TScene>(TScene scene)
            where TScene : Scene
        {
            OnSceneStartedLoading?.Invoke(CurrentScene);
            
            CurrentScene?.Dispose();
            CurrentScene = scene;
            
            scene.BeforeSceneLoaded();
            Loader.LoadScene(scene.GetSceneName(), () => Complete(scene));
        }

        private static void Complete<TScene>(TScene scene) 
            where TScene : Scene
        {
            Resolver.Instance().InjectScene(scene);

            Scene prevScene = CurrentScene;

            scene.OnLoaded();

            OnSceneLoaded?.Invoke(prevScene, scene);
        }

        public static void Tick()
        {
            CurrentScene?.Tick();
        }
    }
}