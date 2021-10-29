using UnityEngine;
using UnityEngine.UI;

public class BonusSpeed : MonoBehaviour
{
    private Text _txtBooster;
    private AudioSource _soundsTakeBonus;
    private ParticleSystem _colorSpeedUp;

    private const int SpeedBonus = 2;

    private void Start()
    {
        _txtBooster = GetComponent<Bonus>().TxtBooster;
        _soundsTakeBonus = GetComponent<Bonus>().SoundsTakeBonus;
        _colorSpeedUp = GetComponent<Bonus>().ColorSpeedUp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMover player))
        {
            player.SetBonusSpeed(SpeedBonus);

            _soundsTakeBonus.Play();
            _colorSpeedUp.startColor = Color.blue;
            _txtBooster.text = "BOOSTER";

            Destroy(gameObject);
        }

        if (collision.TryGetComponent(out Delete delete))
        {
            Destroy(gameObject);
        }
    }
}
