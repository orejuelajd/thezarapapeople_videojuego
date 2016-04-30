using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	public float multiplier = 0.0f;
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Input.GetAxis("Horizontal") * multiplier,0f,Input.GetAxis("Vertical") * multiplier);
	}
}
