using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
	public GameObject obstaclePrefab;

	public float spawnStartTime = 1f;
	public float spawnFrequency = 0.3f;

	private float minXpos = -2f;
	private float maxXpos = 2f;
	private float offsetPos = 0.5f;
	private float boardOffset = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        Camera mainCamera = Camera.main;
        float screenHeight = 2f * mainCamera.orthographicSize;
 		float screenWeigth = screenHeight * mainCamera.aspect;
 		float obstacleSizeX = obstaclePrefab.GetComponent<Renderer>().bounds.size.x;

 		offsetPos = obstacleSizeX / 2;
 		maxXpos = (screenWeigth / 2)  - offsetPos - boardOffset;
 		minXpos = -1 * maxXpos;

 		InvokeRepeating("SpawnObstacle", spawnStartTime, spawnFrequency);
    }

    void SpawnObstacle()
    {
        Vector3 spawnerPosition = transform.position;
        Vector3 position = new Vector3(Random.Range(minXpos, maxXpos), spawnerPosition.y, 0);
        Instantiate(obstaclePrefab, position, Quaternion.identity);
    }
}
