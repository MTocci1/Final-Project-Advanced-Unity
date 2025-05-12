using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject cloudPrefab;
    public Transform startPoint;
    public Transform endPoint;
    public float spawnInterval = 3f;
    public float speedVariation = 2f;
    public float baseScale = 2f;
    public float scaleVariation = 1f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnCloud();
        }
    }

    void SpawnCloud()
    {
        // Pick a random point along the line
        float t = Random.Range(0f, 1f);
        Vector3 spawnPos = Vector3.Lerp(startPoint.position, endPoint.position, t);

        // Instantiate cloud
        GameObject cloud = Instantiate(cloudPrefab, spawnPos, Quaternion.identity);
        CloudMovement cloudMovement = cloud.GetComponent<CloudMovement>();

        // Randomize speed and scale
        float speed = cloudMovement.speed + Random.Range(-speedVariation, speedVariation);
        float scale = baseScale + Random.Range(-scaleVariation, scaleVariation);
        cloud.transform.localScale = Vector3.one * scale;

        cloudMovement.speed = speed;
    }
}
