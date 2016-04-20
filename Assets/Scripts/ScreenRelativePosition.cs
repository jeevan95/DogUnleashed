using UnityEngine;
using System.Collections;

public class ScreenRelativePosition : MonoBehaviour {

	public enum Edges {LEFT, RIGHT, TOP, BOTTOM};
	public Edges screenEdge;
	public float yDelta;
	public float xDelta;


	void Start () {

		Vector3 newPosition = transform.position;
		Camera camera = Camera.main;

		switch(screenEdge)
		{

		case Edges.RIGHT:
			newPosition.x = camera.aspect * camera.orthographicSize + xDelta;
			newPosition.y = yDelta;
			break;

		case Edges.TOP:
			newPosition.y = camera.orthographicSize + yDelta;
			newPosition.x = xDelta;
			break;

		case Edges.LEFT:
			newPosition.x = -camera.aspect * camera.orthographicSize + xDelta;
			newPosition.y = yDelta;
			break;

		case Edges.BOTTOM:
			newPosition.y = -camera.orthographicSize + yDelta;
			newPosition.x = xDelta;
			break;
		}
			
		transform.position = newPosition;
	}
	

}
