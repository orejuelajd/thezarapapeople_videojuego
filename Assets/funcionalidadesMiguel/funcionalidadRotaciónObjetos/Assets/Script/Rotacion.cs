using UnityEngine;
using System.Collections;

public class Rotacion : MonoBehaviour {

	public float velocidadRotacion = 80f;
	public bool rotacionX = false;
	public bool rotacionY = true;
	public bool rotacionZ = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( rotacionX ){
			transform.Rotate( velocidadRotacion * Time.deltaTime, 0f, 0f );
		}

		if( rotacionY ){
			transform.Rotate( 0f, velocidadRotacion * Time.deltaTime, 0f );
		}

		if( rotacionZ ){
			transform.Rotate( 0f, 0f, velocidadRotacion * Time.deltaTime );
		}
	}
}
