using UnityEngine;
using System.Collections;

public class MoveCube : MonoBehaviour {

    public float moveSpeed = 10.0f;

    public float cubeJump = 10.0f;



    void Start () {
 
    }
	
	
	void Update () {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal")*Time.deltaTime*moveSpeed,0.0f,0.0f));
        transform.Translate(new Vector3(0.0f, 0.0f, Input.GetAxis("Vertical") * Time.deltaTime*moveSpeed));
        if (Input.GetKeyDown("space"))
        {
            transform.Translate(Vector3.up*260*Time.deltaTime,Space.World);
        }
	}
}
