
using UnityEngine;
using UnityEngine.Audio;

public class audio_menu : MonoBehaviour
{
    
    public AudioMixer audioMixer;
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }


}
