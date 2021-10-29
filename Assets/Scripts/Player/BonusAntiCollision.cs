using UnityEngine;
using UnityEngine.UI;

public class BonusAntiCollision : MonoBehaviour
{
    private Text _txtBooster;
    private AudioSource _soundsTakeBonus;
    private GameObject _auraAntiCollision;

    private void Start()
    {
        _txtBooster = GetComponent<Bonus>().TxtBooster;
        _soundsTakeBonus = GetComponent<Bonus>().SoundsTakeBonus;
        _auraAntiCollision = GetComponent<Bonus>().AuraAntiCollision;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.GetComponent<CircleCollider2D>().isTrigger = true;

            _soundsTakeBonus.Play();
            _auraAntiCollision.SetActive(true);
            _txtBooster.text = "AntI\nCollisioN";

            Destroy(gameObject);
        }

        if (collision.TryGetComponent(out Delete delete))
        {
            Destroy(gameObject);
        }
    }
}
