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
            for (int j = 0; j < 300; j++)
            {
                var point = GetRandomPoint();
                var result = Physics2D.OverlapCircleAll(point, size);

                if (result.Length > 0)
                {
                    bool nextTry = false;
                    
                    for (int index = 0; index < result.Length; index++)
                    {
                        if(!result[index].isTrigger)
                            nextTry = true;
                    }

                    if(nextTry)
                        continue;
                }

                return point;
            }
            
            return Vector2.zero;
        }

        private Vector3 GetRandomPoint()
        {
            return new Vector3(
                UnityEngine.Random.Range(LeftDownCorner.x, RightDownCorner.x),
                UnityEngine.Random.Range(LeftDownCorner.y, LeftUpCorner.y), 
                0);
        }
    }
}