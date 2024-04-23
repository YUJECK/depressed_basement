using CodeBase.Interactions;
using destructive_code.Scenes;      

public class FightRooomDoorInteraction : Interaction
{
    public override void Interact()
    {
        SceneSwitcher.BasementScene.RoomSwitcher.SwitchTo<FightRoomCode.FightRoom>();
    }
}