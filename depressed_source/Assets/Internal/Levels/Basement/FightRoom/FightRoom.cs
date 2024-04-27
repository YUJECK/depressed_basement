using CodeBase.GameStates;
using CodeBase.Rooms;
using destructive_code.Scenes;
using PlayerStuff;

namespace FightRoomCode
{
    public sealed class FightRoom : Room
    {
        public override void OnEnter(Player player)
        {
            base.OnEnter(player);
            
            SceneSwitcher.BasementScene.UpdateGameStateTo(new FightState(20));
        }
    }
}