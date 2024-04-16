using System;
using System.Collections.Generic;
using destructive_code.Scenes;
using UnityEngine;

namespace CodeBase.Rooms
{
    public class RoomSwitcher
    {
        private readonly Dictionary<Type, Room> typeToRoom = new();

        public RoomSwitcher(Transform roomsContainer)
        {
            var rooms = roomsContainer.GetComponentsInChildren<Room>();

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
                SceneSwitcher.BasementScene.Player.transform.position = room.StartPoint.position;
                
                
            }
        }
    }
}