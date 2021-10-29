using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Disable Objects")]
    [SerializeField] private Buttons _buttons;
    [SerializeField] private Spawn _spawn;
    [SerializeField] private BlackHole _blackHole;
    [Header("Enable Objects")]
    [SerializeField] private GameOverPanel _gameOverPanel;
    [SerializeField] private GameObject _openOutToSpace;
    [Header("Bonus Objects")]
    [SerializeField] private GameObject _auraAntiCollision;

    public bool IsGameOver { get; private set; }

    public void EnableAnticollisionAura()
    {
        _auraAntiCollision.SetActive(true);
    }

    public void DisableAnticollisionAura()
    {
        _auraAntiCollision.SetActive(false);
    }

    private void OnEnable()
    {
        IsGameOver = false;
    }

    private void OnDisable()
    {
        IsGameOver = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out BlackHole blackHole))
        {
            DisableObjects();
            EnableGameOverPanel();
            DeleteAllBloks();
        }
        else if (collision.TryGetComponent(out EmptySpace emptySpace))
        {
            DisableObjects();
            EnableGameOverPanel();
            DeleteAllBloks();

            _openOutToSpace.SetActive(true);
        }
    }

    private void DisableObjects()
    {
        _buttons.gameObject.SetActive(false);
        _spawn.gameObject.SetActive(false);
        _blackHole.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    private void EnableGameOverPanel()
    {
        _gameOverPanel.gameObject.SetActive(true);
    }

    private void DeleteAllBloks()
    {
        var blocks = FindObjectsOfType<BlocksMover>();

        foreach (var block in blocks)
        {
            Destroy(block);
        }
    }
}
