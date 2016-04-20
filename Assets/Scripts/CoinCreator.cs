using UnityEngine;
using System.Collections;

public class CoinCreator : MonoBehaviour {


	public float minSpawnPeriod = 1f; 
	public float maxSpawnPeriod = 2f; 
	public GameObject coinObjectPrefab;
	private Transform spawnArea;



	void Start () {
		spawnArea = GameObject.Find("SpawnPoint").transform;
		Invoke("SpawnCoin",minSpawnPeriod);
	}


	void SpawnCoin()
	{

		float yMax = Camera.main.orthographicSize - 0.5f;
		Vector3 coinPosition = new Vector3( spawnArea.position.x, 
			Random.Range(-yMax, yMax-2f), 
			transform.position.z );

		Instantiate(coinObjectPrefab, coinPosition, Quaternion.identity);
		Invoke("SpawnCoin", Random.Range(minSpawnPeriod, maxSpawnPeriod));

	}
}
