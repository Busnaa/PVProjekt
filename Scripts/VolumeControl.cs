using UnityEngine;

public class VolumeControl : MonoBehaviour
{
    private AudioSource audioSrc; // Reference to the AudioSource component

    private float musicVolume = 0.2f; // Default music volume

    void Start()
    {
        audioSrc = GetComponent<AudioSource>(); // Get the AudioSource component from the same GameObject
    }

    void Update()
    {
        audioSrc.volume = musicVolume; // Update the volume of the AudioSource
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol; // Set the music volume to the provided value
    }
}
