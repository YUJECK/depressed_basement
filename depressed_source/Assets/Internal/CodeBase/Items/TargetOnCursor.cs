using CodeBase.Helpers;
using destructive_code.Scenes;
using UnityEngine;

namespace CodeBase.Items
{
    public class TargetOnCursor : MonoBehaviour
    {
        [SerializeField] private Transform owner;

        public float Coefficient => 1;
        public Vector3 CursorPosition => SceneSwitcher.CurrentScene.GetCamera().ScreenToWorldPoint(Input.mousePosition);
        

        private void Update()
        {
            transform.rotation = Quaternion.Euler(0, 0, AngleCalculator.GetAngle(CursorPosition, transform.position));
        }
    }
}