using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour {


	public float speed = -1;
	public bool collected = false;

	void Start () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
	}
	

	void Update () {
	
	}
		
	void OnBecameInvisible()
	{
		Destroy (gameObject); 
	}


	void coinTaken()
	{
		DestroyObject( gameObject );
	}


}
