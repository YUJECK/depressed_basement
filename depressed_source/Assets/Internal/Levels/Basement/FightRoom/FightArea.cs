using System;
using UnityEngine;

namespace FightRoomCode
{
    [Serializable]
    public class FightArea
    {
        [field: SerializeField] public Vector2 LeftDownCorner { get; private set; }
        [field: SerializeField] public Vector2 LeftUpCorner { get; private set; }
        [field: SerializeField] public Vector2 RightDownCorner { get; private set; }
        [field: SerializeField] public Vector2 RightUpCorner { get; private set; }

        public Vector2 GetRandomEmptyPoint(float size = 0.5f)
        {
            int i = 0;
            while (i < 100)
            {
                i++;
                var point = GetRandomPoint();
                var result = Physics2D.OverlapCircleAll(point, size);

                if (result.Length > 0)
                {
                    size = 0.5f;
                    continue;
                }

                return point;
                break;
            }
            
            return Vector2.zero;
        }

        private Vector2 GetRandomPoint()
        {
            return new Vector2(UnityEngine.Random.Range(LeftDownCorner.x, RightDownCorner.x), UnityEngine.Random.Range(LeftDownCorner.y,
                LeftUpCorner.y));
        }
    }
}