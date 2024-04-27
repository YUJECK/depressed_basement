using AutumnForest;
using UnityEngine;

public class PitchedAudioMonoBehaviour : MonoBehaviour
{
    [SerializeField] private PitchedAudio pitchedAudio;

    public void Play()
    {
        pitchedAudio.Play();
    }

    public void Stop()
    {
        pitchedAudio.Stop();
    }

    public void Pause()
    {
        pitchedAudio.Pause();
    }
}
