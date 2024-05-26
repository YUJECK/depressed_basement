using System;
using System.Collections.Generic;
using DefaultNamespace.MainGameplay;
using destructive_code.Scenes;
using destructive_code.Sounds;
using UnityEngine;

namespace CodeBase.Rooms
{
    public class RoomSwitcher
    {
        public Room CurrentRoom { get; private set; }
        
        private readonly Dictionary<Type, Room> typeToRoom = new();
        private readonly BasementScene basementScene;
        
        public RoomSwitcher(Transform roomsContainer, BasementScene basementScene)
        {
            var rooms = roomsContainer.GetComponentsInChildren<Room>();
            this.basementScene = basementScene;

            ParseToDictionary(rooms);
        }

        private void ParseToDictionary(Room[] rooms)
        {
            foreach (var room in rooms)
            {
                typeToRoom.Add(room.GetType(), room);
            }
        }

        public TRoom Get<TRoom>()
            where TRoom : Room
        {
            return typeToRoom[typeof(TRoom)] as TRoom;
        }

        public void SwitchTo<TRoom>()
            where TRoom : Room
        {
            if (typeToRoom.TryGetValue(typeof(TRoom), out var room))
            {
                basementScene.Player.Weapon.StopCurrentWeaponAction();
                basementScene.Player.transform.position = room.StartPoint.position;
                
                if(basementScene.Player.Movement.WalkSound != "")
                {
                    AudioPlayer.Stop(basementScene.Player.Movement.WalkSound);
                }

                basementScene.Player.Movement.WalkSound = room.WalkSound;

                if(CurrentRoom != null)
                {
                    CurrentRoom.Camera.gameObject.SetActive(false);
                    room.OnExit(SceneSwitcher.BasementScene.Player);
                }

                room.Camera.gameObject.SetActive(true);

                if(room.DoorSound != "")
                    AudioPlayer.Play(room.DoorSound);
                
                room.OnEnter(SceneSwitcher.BasementScene.Player);
                CurrentRoom = room;
            }
        }
    }
}