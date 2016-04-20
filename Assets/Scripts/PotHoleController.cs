using UnityEngine;
using System.Collections;

public class PotHoleController : MonoBehaviour {
	public float speed = -1;
	public bool hit;


	void Start () {
		hit = false;
		GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);

	}
	

	void Update () {
		
	}

	void OnBecameInvisible()
	{
		Destroy (gameObject); 

	}



			

	
}
