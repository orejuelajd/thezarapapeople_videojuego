using UnityEngine;
using System.Collections;

public class Jump: MonoBehaviour {
	
	public float jumpForce = 500;
	public string inputKeyJump = "Jump";
	private bool isJumping = false;
	
	void Start () {
	}
	
	void Update () {
		moveCharacter();
	}
	
	// Method which allows character movement
	void moveCharacter(){
		if (Input.GetButtonDown (inputKeyJump)) {
			jump();
		}
	}
	
	// Method that detect if the character is landed
	void OnCollisionEnter(Collision collision){
		isJumping = false;
	}
	
	public void jump(){
		// If the character isnt jumping ... ¡Jump!
		if ( isJumping == false) {
			isJumping = true;
			gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
		}
	}
} 