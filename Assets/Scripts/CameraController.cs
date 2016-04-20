using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public float speed = 1f;
	private Vector3 newPos;

	void Start () {
		newPos = transform.position;
	}
	

	void Update () {
		newPos.x += Time.deltaTime * speed;
		transform.position = newPos;
	}


	public IEnumerator speedUp(float dogSpeed){
		float temp = this.speed;
		this.speed = 0.5f+dogSpeed;
		yield return new WaitForSeconds(1.5f); 
		this.speed = temp;
	}


}
