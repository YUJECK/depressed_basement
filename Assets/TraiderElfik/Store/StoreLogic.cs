using CodeBase;
using CodeBase.Inputs;
using destructive_code.Sounds;

namespace TraiderElfik
{
    public sealed class StoreLogic : DepressedBehaviour
    {
        public void DisableStoreUI()
        {
            gameObject.SetActive(false);
            InputsHandler.EnterPlayerMode();
            AudioPlayer.Play("StoreClick");
        }
    }
}