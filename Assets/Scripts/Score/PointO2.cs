using UnityEngine;
using UnityEngine.UI;

public class PointO2 : MonoBehaviour
{
    private Spawn _spawn;
    private Text _txtBooster;
    private Buttons _buttons;
    private BlackHole _blackHole;
    private GameOverPanel _gameOver;
    private PlayerMover _playerMover;
    private ParticleSystem _effectsO2;
    private ParticleSystem _colorSpeedUp;
    private AudioSource _soundsTakePoint;
    private CircleCollider2D _playerCollision;

    private const int SpeedBonusOn = 2;
    private const int SpeedBonusOff = 1;

    public void Init(Text txtBoost, AudioSource soundTakePoint, Spawn spawn, Buttons buttons, BlackHole blackHole, GameOverPanel gameOver, CircleCollider2D collider2D, ParticleSystem particleSystem)
    {
        _colorSpeedUp = particleSystem;
        _txtBooster = txtBoost;
        _soundsTakePoint = soundTakePoint;
        _spawn = spawn;
        _buttons = buttons;
        _blackHole = blackHole;
        _gameOver = gameOver;
        _playerCollision = collider2D;
    }

    private void Start()
    {
        _playerMover = FindObjectOfType<PlayerMover>();
        _effectsO2 = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.TryGetComponent(out PlayerMover playerMover))
        {
            var player = playerMover.GetComponent<Player>();

            if (playerMover.BonusSpeed == SpeedBonusOn)
            {
                playerMover.SetBonusSpeed(SpeedBonusOff);
                _txtBooster.text = " ";
                _colorSpeedUp.startColor = Color.white;
            }

            if (_playerCollision.isTrigger == true)
            {
                _playerCollision.isTrigger = false;
            }

            player.DisableAnticollisionAura();
            playerMover.OnTakePoint();

            _soundsTakePoint.Play();
            _effectsO2.Play();

            Destroy(gameObject);
        }

        if (collision.TryGetComponent(out BlocksMover blocksMover))
        {
            Destroy(gameObject);
        }

        if (collision.TryGetComponent(out BonusSpeed bonusSpeed))
        {            
            Destroy(gameObject);
        }

        if (collision.TryGetComponent(out BonusAntiCollision bonusAntiCollision))
        {
            Destroy(gameObject);
        }

        if (collision.TryGetComponent(out BlackHole blackHole))
        {
            DisableObjects();
            EnableObjects();
            Destroy(gameObject);
        }
    }

    private void DisableObjects()
    {
        _playerMover.gameObject.SetActive(false);
        _buttons.gameObject.SetActive(false);
        _blackHole.gameObject.SetActive(false);
        _spawn.gameObject.SetActive(false);

        gameObject.SetActive(false);
    }

    private void EnableObjects()
    {
        _gameOver.gameObject.SetActive(true);
    }
}
