using UnityEngine;

namespace Enemies
{
    public sealed class BarbedDummyAnimator : MonoBehaviour
    {
        public void ActivateAI()
        {
            GetComponentInParent<BarbedDummyAI>().enabled = true;
        }
    }
}