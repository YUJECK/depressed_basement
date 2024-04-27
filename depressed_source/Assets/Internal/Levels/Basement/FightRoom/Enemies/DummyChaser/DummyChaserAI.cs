using CodeBase.Helpers;
using Internal.CodeBase.Enemies;
using UnityEngine;

namespace FightRoomCode.Enemies.DummyChaser
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class DummyChaserAI : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private TriggerHandler handler;

        private TargetRadar _radar;
        private Rigidbody2D _rigidbody2D;

        private void Start()
        {
            _radar = GetComponentInChildren<TargetRadar>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (_radar.CurrentTarget != null)
            {
                _rigidbody2D.MovePosition(Vector3
                    .MoveTowards(transform.position, _radar.CurrentTarget.transform.position, speed * 10 * Time.deltaTime));
            }
        }
    }
}