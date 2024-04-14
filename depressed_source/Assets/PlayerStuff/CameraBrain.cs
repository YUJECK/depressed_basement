using System;
using Cinemachine;
using CodeBase.Hits;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace PlayerStuff
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public sealed class CameraBrain : MonoBehaviour
    {
        private CinemachineVirtualCamera _virtualCamera;

        private void Start()
        {
            _virtualCamera = GetComponent<CinemachineVirtualCamera>();
            HitHandler.OnHit += OnHit;
        }

        private void OnHit(Health health, HitData arg2)
        {
            if(health is PlayerHealth)
            {
                Shake(2, 0.2f);
            }
            else
            {
                Shake(1, 0.1f);
            }
        }

        public async void Shake(float intensity, float time)
        {
            var shake = _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            shake.m_AmplitudeGain = intensity;

            await UniTask.Delay(TimeSpan.FromSeconds(time));
            
            shake.m_AmplitudeGain = 0;
        }
    }
}