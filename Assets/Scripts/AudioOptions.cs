using UnityEngine;
using UnityEngine.Audio;

public class AudioOptions : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup MasterVol;
    [SerializeField] private AudioSource soundEffect;

    public void SwitchMusic(bool enabled)
    {
        soundEffect.Play();
        if (enabled)
        {
            MasterVol.audioMixer.SetFloat("MusicBG", -5f);
        }
        else
        {
            MasterVol.audioMixer.SetFloat("MusicBG", -80f);
        }
    }

    public void SwitchSFX(bool enabled)
    {
        soundEffect.Play();
        if (enabled)
        {
            MasterVol.audioMixer.SetFloat("SoundsEffects", -5f);
        }
        else
        {
            MasterVol.audioMixer.SetFloat("SoundsEffects", -80f);
        }
    }
}
