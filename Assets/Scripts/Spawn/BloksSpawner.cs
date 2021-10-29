using System.Collections;
using UnityEngine;

public class BloksSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPositions;
    [SerializeField] private Vector2 spawnRange;
    [SerializeField] private GameObject[] RandomizeBlocks;

    public static float spawnTimeMin = 2.0f;
    public static float spawnTimeMax = 8.0f;

    public void Start()
    {
        StartCoroutine(Spawn());        
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(spawnTimeMin, spawnTimeMax));
        Vector2 pos = spawnPositions.position + new Vector3(Random.Range(-spawnRange.x, spawnRange.x), 0, 0);
        Instantiate(RandomizeBlocks[Random.Range(0, 2)], pos, Quaternion.AngleAxis(Random.Range(0f, 360f), Vector3.forward));
        Repeat();
    }

    public void Repeat()
    {
        StartCoroutine(Spawn());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Delete")
        {
            Destroy(this.gameObject);
        }
    }
}
