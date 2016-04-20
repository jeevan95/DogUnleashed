using UnityEngine;
using System.Collections;

public class BoneCreator : MonoBehaviour {


	public float minSpawnPeriod = 1f; 
	public float maxSpawnPeriod = 2f; 
	public GameObject boneObjectPrefab;
	private Transform spawnArea;


	   
	void Start () {
		spawnArea = GameObject.Find("SpawnPoint").transform;
		Invoke("SpawnBone",minSpawnPeriod);
	}


	void SpawnBone()
	{

		float yMax = Camera.main.orthographicSize - 0.5f;
		Vector3 bonePosition = new Vector3( spawnArea.position.x, 
			Random.Range(-yMax, yMax-2f), 
			transform.position.z );

		Instantiate(boneObjectPrefab, bonePosition, Quaternion.identity);
		Invoke("SpawnBone", Random.Range(minSpawnPeriod, maxSpawnPeriod));

	}
}
