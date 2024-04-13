using PlayerStuff;
using UnityEngine;

namespace CodeBase.GameState
{
    public class GameplayState : GameState
    {
        public Player Player { get; private set; }

        public int Money { get; set; } = 10;


        public override void OnAdded()
        {
        }

        public override void OnSceneLoaded()
        {
            Player = GameObject.FindObjectOfType<Player>();
        }
        
    }
}