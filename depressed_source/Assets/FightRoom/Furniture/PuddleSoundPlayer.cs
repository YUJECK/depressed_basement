using AutumnForest;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PuddleSoundPlayer : MonoBehaviour
{
    private PitchedAudio _audio;
    
    void Start()
    {
        _audio = new PitchedAudio(GetComponent<AudioSource>());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _audio.Play();
    }
}
