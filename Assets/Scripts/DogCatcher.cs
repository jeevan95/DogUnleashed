using UnityEngine;
using System.Collections;

public class DogCatcher : MonoBehaviour {

	public Transform dog;
	public float chaseSpeed ;
	public float betweenDist;
	public float followSpeed;


	void Update () 
	{
		Vector2 vectorToTarget = dog.position - transform.position;
		vectorToTarget.y = 0;
		float distanceToDog = vectorToTarget.magnitude;


		if (distanceToDog > betweenDist) {
			transform.position = Vector2.MoveTowards (transform.position, dog.position, chaseSpeed * Time.deltaTime);
		} else {
			transform.position = Vector2.MoveTowards (transform.position, dog.position, followSpeed * Time.deltaTime);
		}


	}

}
