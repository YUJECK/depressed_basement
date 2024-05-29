using CodeBase.GameStates;
using CodeBase.Rooms;
using destructive_code.Scenes;
using Internal.Enemies;
using PlayerStuff;
using UnityEngine;

namespace FightRoomCode
{
    public sealed class FightRoom : Room
    {
        [field: SerializeField] public FightArea Area { get; private set; } = new();
        
        private TempObjectsContainer container;

        private void Start()
        {
            container = GetComponentInChildren<TempObjectsContainer>();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            
            Gizmos.DrawLine(Area.LeftDownCorner, Area.LeftUpCorner);
            Gizmos.DrawLine(Area.LeftUpCorner, Area.RightUpCorner);
            Gizmos.DrawLine(Area.RightUpCorner, Area.RightDownCorner);
            Gizmos.DrawLine(Area.RightDownCorner, Area.LeftDownCorner);
        }

        public override void OnEnter(Player player)
        {
            base.OnEnter(player);
            
            SceneSwitcher.BasementScene.UpdateGameStateTo(new FightState(20, container));
        }

        public TObject Spawn<TObject>(TObject prefab, Vector2 position)
            where TObject : MonoBehaviour
        {
            var instance = SceneSwitcher.CurrentScene.Fabric.Instantiate(prefab, position, container.transform);
            
            if(instance is Enemy enemy)
                enemy.SetRoom(this);

            return instance;
        }
        
        public GameObject Spawn(GameObject prefab, Vector2 position)
        {
            return SceneSwitcher.CurrentScene.Fabric.Instantiate(prefab, position, container.transform);
        }
    }
}