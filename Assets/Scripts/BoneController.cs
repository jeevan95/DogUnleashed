using UnityEngine;
using System.Collections;

public class BoneController : MonoBehaviour {
	public float speed = -1;
	public bool eat = false;


	void Start () {
		//GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);

	}
		

	void OnBecameInvisible()
	{
		
		Destroy (gameObject); 

	}

	void boneTaken()
	{
		DestroyObject( gameObject );
	}


}
