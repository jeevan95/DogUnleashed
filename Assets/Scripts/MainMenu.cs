using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {


	public void QuitGame(){
		Application.Quit ();
	}

	public void LoadGame(){
		SceneManager.LoadScene ("Dog Unleashed");
	}


	public void LoadInstructions(){
		SceneManager.LoadScene ("Instructions");
	}

	public void LoadMenu(){
		SceneManager.LoadScene ("Main Menu");
	}


}
