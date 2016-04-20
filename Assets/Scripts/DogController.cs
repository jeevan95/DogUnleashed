using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DogController : MonoBehaviour { 

	public PolygonCollider2D[] colliders;
	public int currentColliderIndex = 0;

	public float upDownSpeed;
	public float runSpeed;
	private  Rigidbody2D rbd;
	private Vector3 moveDirection;
	public float boneBoostSpeed;
	public float potholeHitSpeed;
	public float potholeRecoverSpeed;
	public float boostTime;
	private float defaultSpeed = 1f;
	private GameController gameController;
	private CameraController cameraController;



	void Start () {
		rbd = GetComponent<Rigidbody2D> ();
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if (gameController == null) {
			Debug.Log ("'GameController' script missing");
		}

		GameObject cameraObject = GameObject.FindWithTag ("MainCamera");
		if (cameraObject != null) {
			cameraController = cameraObject.GetComponent<CameraController>();
		}
		if (cameraController == null) {
			Debug.Log ("'CameraController' script missing");
		}


	}
	

	void Update () {
			float y = Input.GetAxis ("Vertical");
			rbd.velocity = new Vector2 (runSpeed, y * upDownSpeed);
			EnforceBounds ();
	}

	public void SetColliderForSprite( int spriteNum )
	{
		colliders[currentColliderIndex].enabled = false;
		currentColliderIndex = spriteNum;
		colliders[currentColliderIndex].enabled = true;
	}

	void OnTriggerEnter2D( Collider2D other )
	{
		if (other.CompareTag ("Bone")) {
			if (!other.GetComponent<BoneController> ().eat) {
				this.runSpeed = this.runSpeed + boneBoostSpeed;
				other.GetComponent<Animator> ().SetBool ("BoneTake", true);
				this.runSpeed = boneBoostSpeed;
				StartCoroutine (stopPowerUp ());
			}
		} else if (other.CompareTag ("PotHole")) {
			if (!other.GetComponent<PotHoleController> ().hit) {
				this.runSpeed = this.runSpeed - potholeHitSpeed;
				GetComponent<Animator> ().SetBool ("PotholeHit", true);
				other.GetComponent<PotHoleController> ().hit = true;
			}
				
		} else if (other.CompareTag ("DogCatcher")) {
			Destroy (other.gameObject);
			Destroy (this.gameObject);
			gameController.GameOver ();
		} else if (other.CompareTag ("Coin")) {
			//increase point
			if (!other.GetComponent<CoinController> ().collected) {
				other.GetComponent<Animator> ().SetBool ("CoinTake", true);
				other.GetComponent<CoinController> ().collected = true;
				gameController.AddScore (1);
			}
		}

	}

	public IEnumerator stopPowerUp(){
		yield return new WaitForSeconds(boostTime); 
		this.runSpeed = defaultSpeed; 
	}
		



	void playFirstAnimation(){
		this.runSpeed = this.runSpeed+potholeRecoverSpeed;
		GetComponent<Animator>().SetBool( "PotholeHit", false );
		GetComponent<Animator> ().Play ("DogRun");
	}
		


	private void EnforceBounds()
	{

		Vector3 newPos = transform.position; 
		Camera cam = Camera.main;
		Vector3 cameraPosition = cam.transform.position;

		float xDistance = cam.aspect * cam.orthographicSize; 
		float xMaxVal = cameraPosition.x + xDistance-3 -0.7f;//-3 to limit x val so dog doesn't go right to RHS edge
		float xMinVal = cameraPosition.x - xDistance;

		//there is an issue where dog gets stuck at rhs and van gets it no matter what
		//we fixed it by increasing the camers speed for a short time 

		if ( newPos.x < xMinVal || newPos.x > xMaxVal ) {
			newPos.x = Mathf.Clamp( newPos.x, xMinVal, xMaxVal );
			moveDirection.x = -moveDirection.x;
			//increase camera speed just for a short bit so do doesn't get too close to edge
			StartCoroutine (cameraController.speedUp(this.runSpeed));
		}

		float yMaxVal = cam.orthographicSize;

		if (newPos.y < -yMaxVal || newPos.y > yMaxVal-10) {
			newPos.y = Mathf.Clamp( newPos.y, -yMaxVal+0.4f, yMaxVal=1.5f );
		}
			
		transform.position = newPos;

	}





}
