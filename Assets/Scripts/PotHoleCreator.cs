using UnityEngine;
using System.Collections;

public class PotHoleCreator : MonoBehaviour {


	public float minSpawnPeriod; 
	public float maxSpawnPeriod; 
	public GameObject potholeObjectPrefab;
	private Transform spawnArea;
	public float reduceTimeBy;
	public float reduceTimeInterval;
	public float spawnTimeLimit;

	void Start () {
		spawnArea = GameObject.Find("SpawnPoint").transform;
		Invoke("SpawnPotHole",minSpawnPeriod);
		InvokeRepeating ("increaseDifficulty", reduceTimeInterval, reduceTimeInterval);
	}


	void SpawnPotHole()
	{

		float yMax = Camera.main.orthographicSize - 0.5f;
		Vector3 potHolePosition = new Vector3( spawnArea.position.x, 
			Random.Range(-yMax, yMax-2f), 
			transform.position.z );
					
		Instantiate(potholeObjectPrefab, potHolePosition, Quaternion.identity);
		Invoke("SpawnPotHole", Random.Range(minSpawnPeriod, maxSpawnPeriod));

	}


	public void increaseDifficulty(){
		if (minSpawnPeriod>spawnTimeLimit) {
			this.maxSpawnPeriod = this.maxSpawnPeriod - reduceTimeBy;
			this.minSpawnPeriod = this.minSpawnPeriod - reduceTimeBy;
		}
	}


}
