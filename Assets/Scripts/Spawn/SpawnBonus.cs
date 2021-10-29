using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpawnBonus : MonoBehaviour
{
    [SerializeField] private Bonus _template;
    [SerializeField] private Player _player;
    [Header("Fields For Template")]
    [SerializeField] private GameObject _auraAntiCollision;
    [SerializeField] private Text _txtBooster;
    [SerializeField] private AudioSource _soundsTakeBonus;
    [SerializeField] private ParticleSystem _colorSpeedUp;

    private Transform _bonusPositions;
    private bool _isGameOver => _player.IsGameOver;

    private const float _spawnTimeMax = 40.0f;
    private const float _spawnTimeMin = 18.0f;
    private const int Range = 40;
    
    private void Start()
    {
        _bonusPositions = transform;
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        var waitForSeconds = new WaitForSeconds(Random.Range(_spawnTimeMin, _spawnTimeMax));

        while (!_isGameOver)
        {
            yield return waitForSeconds;
            Vector2 pos = _bonusPositions.position + new Vector3(Random.Range(-Range, Range), 0, 0);

            var bonus = Instantiate(_template, pos, Quaternion.identity);
            bonus.Init(_txtBooster, _soundsTakeBonus, _colorSpeedUp, _auraAntiCollision);
        }
    }
}
