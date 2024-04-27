using destructive_code.Scenes;
using UnityEngine;

namespace CodeBase.Items
{
    public class TargetOnCursor : MonoBehaviour
    {
        [SerializeField] private Transform owner;

        public float Coefficient => 1;
        public Vector3 CursorPosition => SceneSwitcher.CurrentScene.GetCamera().ScreenToWorldPoint(Input.mousePosition);
        
        private float GetAngle()
        {
            Vector2 direction = CursorPosition - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

            return Coefficient * angle;
        }

        private void Update()
        {
            transform.rotation = Quaternion.Euler(0, 0, GetAngle());
        }
    }
}