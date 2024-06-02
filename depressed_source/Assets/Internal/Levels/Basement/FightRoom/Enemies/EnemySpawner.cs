using System;
using System.Collections.Generic;
using destructive_code.Scenes;
using Enemies;
using UnityEngine;
using UnityEngine.Serialization;

namespace FightRoomCode.Enemies
{
    public sealed class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyPrefabProvider prefabProvider;
        
        private readonly Dictionary<Type, List<AbstractSpawner>> spawners = new();
        private FightRoom fightRoom;
        
        private void Start()
        {
            SceneSwitcher.OnSceneLoaded += OnLoaded;
        }

        private void OnLoaded(Scene arg1, Scene arg2)
        {
            SceneSwitcher.OnSceneLoaded -= OnLoaded;
            
            ResetSpawners();
            
            fightRoom = SceneSwitcher.BasementScene.RoomSwitcher.Get<FightRoom>();
        }

        public void ResetSpawners()
        {  
            AddSpawner(new BarbedDummiesSpawner());
            AddSpawner(new KnifyDummySpawner());
        }

        public void InvokeRandomSpawnerFrom<TSpawner>()
            where TSpawner : AbstractSpawner
        {
            Type spawnerType = typeof(TSpawner);
            
            if(!spawners.TryGetValue(spawnerType, out var list)) return;
            
            list[UnityEngine.Random.Range(0, list.Count)].Spawn(fightRoom, prefabProvider);
        }
        
        public void AddSpawner<TSpawner>(TSpawner spawner)
            where TSpawner : AbstractSpawner
        {
            if(spawner == null) return;

            Type spawnerType = typeof(TSpawner);
            
            if (!spawners.ContainsKey(spawnerType))
            {
                spawners.Add(spawnerType, new List<AbstractSpawner>());
            }
            
            spawners[spawnerType].Add(spawner);
        }

        public void RemoveSpawner<TSpawner>(TSpawner spawner)
            where TSpawner : AbstractSpawner
        {
            if(spawner == null) return;

            Type spawnerType = typeof(TSpawner);
            
            if(!spawners.ContainsKey(spawnerType)) return;

            if (spawners.TryGetValue(spawnerType, out var list))
            {
                list.Remove(spawner);
            }
        }

        public void RemoveSpawner<TSpawner>(int count)
            where TSpawner : AbstractSpawner
        {
            Type spawnerType = typeof(TSpawner);
            
            if(!spawners.ContainsKey(spawnerType)) return;

            if (spawners.TryGetValue(spawnerType, out var list))
            {
                for (int i = 0; i < count && i < list.Count; i++)
                {
                    list.RemoveAt(0);
                }
            }
        }
    }
}