using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class ControlHUD_SelectLevel : MonoBehaviour {
	
	// The current level in which the character is standing
	public string currentLevel = "";
	
	void Start () {
	
	}

	void Update () {

	}
	

	// This method works when the user clicked "Select level" or "Play level"
	// The level clicked will be played by the user
	public void selectLevel(){
		Application.LoadLevel(currentLevel);
	}

	public void back(){
		// Application.LoadLevel(pantalla anterior a la de la seleccion de nivel)
	}
}
