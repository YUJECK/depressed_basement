using System;
using CodeBase.Hits;
using destructive_code.Scenes;
using FightRoomCode;
using PlayerStuff;
using UnityEngine;

namespace CodeBase.FightMiner
{
    public class Miner
    {
        public int Current { get; private set; }
        public event Action<int> OnChanged; 
        
        public void Start()
        {
            HitHandler.OnHit += OnHit;
        }

        public void Stop()
        {
            SceneSwitcher.BasementScene.CheckMachine.PushCheck(new FightCheck(Current));
            
            HitHandler.OnHit -= OnHit;
        }
        
        private void OnHit(Health who, HitData from)
        {
            if (who is PlayerHealth player)
            {
                Current -= from.Damage;
            }
            else
            {
                Current += from.Damage;
            }

            OnChanged?.Invoke(Current);
        }
    }
}