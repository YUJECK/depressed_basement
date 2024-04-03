using CodeBase.Inputs;
using CodeBase.Interactions;
using destructive_code.Sounds;
using UnityEngine;

namespace TraiderElfik
{
    public class ElfikStoreInteraction : Interaction
    {
        [SerializeField] private GameObject storeObject;
        
        public override void Interact()
        {
            storeObject.SetActive(true);
            InputsHandler.EnterUIMode();
            AudioPlayer.Play("StoreClick");
        }
    }
}