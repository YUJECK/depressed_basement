using System;
using System.Collections.Generic;
using DefaultNamespace.MainGameplay;
using destructive_code.Scenes;
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

        public void SwitchTo<TRoom>()
            where TRoom : Room
        {
            if (typeToRoom.TryGetValue(typeof(TRoom), out var room))
            {
                basementScene.Player.transform.position = room.StartPoint.position;
                basementScene.Player.Movement.WalkSound = room.WalkSound;
                
                if(CurrentRoom != null)
                    CurrentRoom.Camera.gameObject.SetActive(false);
                
                room.Camera.gameObject.SetActive(true);
                
                CurrentRoom = room;

            }
        }
    }
}