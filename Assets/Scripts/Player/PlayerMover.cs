using UnityEngine;
using UnityEngine.Events;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private ParticleSystem _fx;
    [SerializeField] private ParticleSystem _fxRight;
    [SerializeField] private ParticleSystem _fxLeft;

    [SerializeField] private float _leftEdge;
    [SerializeField] private float _rightEdge;

    private float _elapsedTime = 3f;
    private int _directionLeft;
    private int _directionRight;
    private int _directionUp;
    private int _bonusSpeed = 1;

    private bool _hasLeftSlide;
    private bool _hasRightSlide;
    private Rigidbody2D _rigidBody;

    private const float SidewaySpeed = 30f;
    private const float UpAccelerationsSpeed = 60f;

    public int BonusSpeed => _bonusSpeed;

    public event UnityAction PointTaked;

    public void SetBonusSpeed(int value)
    {
        _bonusSpeed = value;
    }

    public void SetDirectionY(int directionUp)
    {
        _directionUp = directionUp;
    }

    public void SetDirectionX(int directionLeft, int directionRight, bool isLeft, bool isRight)
    {
        _directionLeft = directionLeft;
        _hasLeftSlide = isLeft;

        _directionRight = directionRight;
        _hasRightSlide = isRight;
    }

    public void OnTakePoint()
    {
        PointTaked?.Invoke();
    }

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _bonusSpeed = 0;
    }

    private void FixedUpdate()
    {
        if (_hasLeftSlide)
            ToLeft();
        else if (_hasRightSlide)
            ToRight();
        else
            ResetVelocity();

        Up();
        PlayEffectsSlide();
        PlayEffectsUp();

        _elapsedTime -= Time.deltaTime;
        if (_elapsedTime >= 0)
            _bonusSpeed = 1;
    }

    private void ToLeft()
    {
        if (transform.position.x < _leftEdge)
        {
            ResetVelocity();
            return;
        }
        
        _rigidBody.velocity = new Vector2(_directionLeft * (SidewaySpeed * _bonusSpeed), _rigidBody.velocity.y);
    }

    private void ToRight()
    {
        if (transform.position.x > _rightEdge)
        {
            ResetVelocity();
            return;
        }

        _rigidBody.velocity = new Vector2(_directionRight * (SidewaySpeed * _bonusSpeed), _rigidBody.velocity.y);
    }

    private void Up()
    {
        _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _directionUp * (UpAccelerationsSpeed * _bonusSpeed));
    }

    private void ResetVelocity()
    {
        _rigidBody.velocity = new Vector2(0, _rigidBody.velocity.y);
    }

    private void PlayEffectsSlide()
    {
        if (_directionLeft != 0)
            _fxRight.Play();
        else if (_directionRight != 0)
            _fxLeft.Play();
        else
        {
            _fxLeft.Stop();
            _fxRight.Stop();
        }
    }

    private void PlayEffectsUp()
    {
        if (_directionUp != 0)
            _fx.Play();
        else
            _fx.Stop();
    }
}
