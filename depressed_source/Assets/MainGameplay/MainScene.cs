using CodeBase.GameState;
using destructive_code.Scenes;
using UnityEngine;

namespace DefaultNamespace.MainGameplay
{
    public class MainScene : Scene
    {
        public override string GetSceneName()
        {
            return "SampleScene";
        }

        public override Camera GetCamera()
        {
            return Camera.main;
        }

        public override void BeforeSceneLoaded()
        {
            UpdateGameStateTo(new GameplayState());
        }

        protected override void OnSceneLoaded()
        {
            State.OnSceneLoaded();
        }
    }
} 