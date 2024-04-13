using CodeBase.GameState;
using UnityEngine;

namespace destructive_code.Scenes
{
    public abstract class Scene
    {
        public abstract string GetSceneName();
        public abstract Camera GetCamera();

        public virtual GameObjectFabric Fabric { get; private set; } = new GameObjectFabric();

        public GameState State { get; protected set; }

        public bool TryGetState<TState>(out TState state)
            where TState : GameState
        {
            state = State as TState;
            
            return state != null;
        }
        
        public void UpdateGameStateTo(GameState state)
        {
            if(state == null) return;
            
            State = state;
            state.OnAdded();
        }
        
        public virtual void BeforeSceneLoaded() {}

        public void OnLoaded()
        {
            OnSceneLoaded();
            State?.OnSceneLoaded();
        }
        
        protected abstract void OnSceneLoaded();
        public virtual void Tick() {}
        public virtual void Dispose() {}
    }    
}