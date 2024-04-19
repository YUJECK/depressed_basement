using CodeBase.GameStates;
using CodeBase.Rooms;
using destructive_code.Scenes;
using PlayerStuff;

namespace DefaultNamespace.Shop
{
    public sealed class ShopRoom : Room
    {
        public override void OnEnter(Player player)
        {
            SceneSwitcher.BasementScene.UpdateGameStateTo(new ShopState());
        }

        public override void OnExit(Player player)
        {
            
        }
    }
}