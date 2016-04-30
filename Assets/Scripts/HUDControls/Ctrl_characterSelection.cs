using UnityEngine;
using System.Collections;

public class Ctrl_characterSelection : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void next(){
		Application.LoadLevel("worldSelection");
	}

	public void back(){
		Application.LoadLevel("menuStart");
	}
}
