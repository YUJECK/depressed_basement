using CodeBase.Interactions;
using UnityEngine;

namespace TraiderElfik
{
    public class ElfikStoreInteraction : Interaction
    {
        [SerializeField] private StoreLogic logic;
        
        public override void Interact()
        {
            logic.EnableStoreUI();
        }
    }
}