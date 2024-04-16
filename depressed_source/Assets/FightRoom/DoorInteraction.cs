using Cinemachine;
using CodeBase.Interactions;
using destructive_code.Scenes;
using UnityEngine;

public class DoorInteraction : Interaction
{
    [SerializeField] private Transform fightDoorPoint; 
    [SerializeField] private CinemachineVirtualCamera fightCamera; 
    [SerializeField] private CinemachineVirtualCamera shopCamera; 
    
    public override void Interact()
    {
        shopCamera.gameObject.SetActive(false);
        fightCamera.gameObject.SetActive(true);

        SceneSwitcher.BasementScene.Player.transform.position = fightDoorPoint.position;
    }
}
