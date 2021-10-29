using UnityEngine;
using UnityEngine.UI;

public class Bonus : MonoBehaviour
{
    public Text TxtBooster { get; private set; }
    public AudioSource SoundsTakeBonus { get; private set; }
    public ParticleSystem ColorSpeedUp { get; private set; }
    public GameObject AuraAntiCollision { get; private set; }

    public void Init(Text txtBooster, AudioSource sound, ParticleSystem colorSpeedUp, GameObject aura)
    {
        TxtBooster = txtBooster;
        SoundsTakeBonus = sound;
        ColorSpeedUp = colorSpeedUp;
        AuraAntiCollision = aura;
    }
}
