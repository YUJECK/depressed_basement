namespace CodeBase.GameState
{
    public abstract class GameState
    {
        public virtual void OnAdded() {}
        public virtual void OnSceneLoaded() {}
        public virtual void OnExit() {}
    }
}