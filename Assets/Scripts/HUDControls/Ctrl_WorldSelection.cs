using UnityEngine;
using System.Collections;

public class Ctrl_WorldSelection : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void next(){
		Application.LoadLevel("levelSelection");
	}

	public void back(){
		Application.LoadLevel("characterSelection");
	}
}
