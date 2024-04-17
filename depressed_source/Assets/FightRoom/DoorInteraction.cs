using Cinemachine;
using CodeBase.Interactions;
using DefaultNamespace.FightRoom;
using destructive_code.Scenes;
using UnityEngine;

public class DoorInteraction : Interaction
{
    public override void Interact()
    {
        SceneSwitcher.BasementScene.RoomSwitcher.SwitchTo<FightRoom>();
    }
}