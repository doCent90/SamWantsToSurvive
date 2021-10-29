using UnityEngine;

public class Buttons : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;

    public void Left()
    {
        _playerMover.SetDirectionX(-1, 0, true, false);
    }

    public void Right()
    {
        _playerMover.SetDirectionX(0, 1, false, true);
    }

    public void Up()
    {
        _playerMover.SetDirectionY(1);
    }

    public void ResetSlide()
    {
        _playerMover.SetDirectionX(0, 0, false, false);
    }

    public void ResetUp()
    {
        _playerMover.SetDirectionY(0);
    }
}