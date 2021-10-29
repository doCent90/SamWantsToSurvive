using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text _scoreTxt;
    [SerializeField] private Text _bestScoreTxt;
    [SerializeField] private Text _lvlNow;
    [SerializeField] private PlayerMover _player;
    [SerializeField] private Rigidbody2D _rigidbodyPlayer;

    private int _bestScore;
    private int _currentLevel;
    private int _scoreCount;

    private const float CurrentGarvityScale = 200;
    private const string BestScore = "best";

    private void OnEnable()
    {
        _rigidbodyPlayer.gravityScale = CurrentGarvityScale;
        _player.PointTaked += OnPointTaked;
    }

    private void OnDisable()
    {
        _player.PointTaked -= OnPointTaked;
    }

    private void Start()
    {
        _currentLevel = 0;
        _scoreCount = 0;

        _scoreTxt.text = "Score: " + _scoreCount;
        _bestScoreTxt.text = PlayerPrefs.GetInt(BestScore) + " :best";

        _lvlNow.text = $"LVL {_currentLevel}";
    }

    private void OnPointTaked()
    {
        _scoreCount++;

        if (PlayerPrefs.GetInt(BestScore) < _scoreCount)
        {
            PlayerPrefs.SetInt(BestScore, _scoreCount);
        }

        _bestScore = PlayerPrefs.GetInt(BestScore);
        _scoreTxt.text = "Score: " + _scoreCount;
        _bestScoreTxt.text = _bestScore + " :besT";

        SetLevelValueText();
        SetValueGravity();

        if (_scoreCount >= 100)
        {
            _lvlNow.text = "Finish, You are survived";
            PlayerPrefs.DeleteKey(BestScore);
        }
    }

    private void SetLevelValueText()
    {
        _currentLevel = _scoreCount / 10;
        _lvlNow.text = $"LVL {_currentLevel}";
    }

    private void SetValueGravity()
    {
        _rigidbodyPlayer.gravityScale = CurrentGarvityScale + (_currentLevel * 10);
    }
}
