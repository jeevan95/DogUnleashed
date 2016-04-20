using UnityEngine;
using System.Collections;

public class BackgroundRepeater : MonoBehaviour {
	private Transform camTransform;
	private float backgroundWidth;

	void Start () {
		camTransform = Camera.main.transform;
		SpriteRenderer spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
		backgroundWidth = spriteRenderer.sprite.bounds.size.x;
	}
	

	void Update () {
		if( (transform.position.x + backgroundWidth) < camTransform.position.x) {
			Vector3 newPos = transform.position;
			newPos.x += 2.0f * backgroundWidth; 
			transform.position = newPos;
		}
	}
}
