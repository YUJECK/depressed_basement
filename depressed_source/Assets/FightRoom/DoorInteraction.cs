using CodeBase.Interactions;
using DefaultNamespace.FightRoom;
using destructive_code.Scenes;      

public class DoorInteraction : Interaction
{
    public override void Interact()
    {
        SceneSwitcher.BasementScene.RoomSwitcher.SwitchTo<FightRoom>();
    }
}