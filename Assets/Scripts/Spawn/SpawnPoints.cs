using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPoints : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PointO2 _template;
    [Header("Fields To Template")]
    [SerializeField] private ParticleSystem _colorSpeedUp;
    [SerializeField] private Text _txtBooster;
    [SerializeField] private AudioSource _soundsTakePoint;
    [SerializeField] private Spawn _spawn;
    [SerializeField] private Buttons _buttons;
    [SerializeField] private BlackHole _blackHole;
    [SerializeField] private GameOverPanel _gameOver;
    [SerializeField] private CircleCollider2D _playerCollision;

    private Transform _positions;
    private bool _isGameOver => _player.IsGameOver;

    private const float TimeMin = 2.0f;
    private const float TimeMax = 8.0f;
    private const int SpawnRange = 40;

    public void Start()
    {
        _positions = transform;
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        var waitForSeconds = new WaitForSeconds(Random.Range(TimeMin, TimeMax));

        while (!_isGameOver)
        {
            yield return waitForSeconds;
            Vector2 pos = _positions.position + new Vector3(Random.Range(-SpawnRange, SpawnRange), 0, 0);

            var point = Instantiate(_template, pos, Quaternion.identity);
            point.Init(_txtBooster, _soundsTakePoint, _spawn, _buttons, _blackHole, _gameOver, _playerCollision, _colorSpeedUp);
        }
    }
}
