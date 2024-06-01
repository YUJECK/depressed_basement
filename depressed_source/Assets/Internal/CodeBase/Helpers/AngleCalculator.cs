using UnityEngine;

namespace CodeBase.Helpers
{
    public static class AngleCalculator
    {
        public static float GetAngle(Vector2 from, Vector2 to)
        {
            Vector2 direction = to - from;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

            return angle;
        }
    }
}