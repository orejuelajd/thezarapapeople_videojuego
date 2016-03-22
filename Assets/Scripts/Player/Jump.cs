using UnityEngine;
using System.Collections;

public class Jump: MonoBehaviour {

	// The character is jumping for first time
	private bool isJumping = false;

	// The character is jumping for second time
	private bool isDoubleJumping = false;

	// the character can jump one time
	public bool hasJumping = false;

	// The character can jump two times
	public bool hasDoubleJumping = false;

	// The character can fall slowly
	public bool hasSlowFall = false;
	
	public float jumpForce = 500;

	void Start () {
	}
	
	void Update () {
		//moveCharacter();
	}
	
	// Method which allows character movement
	void moveCharacter(){

	}
	
	// Method that detect if the character is landed
	void OnCollisionEnter(Collision collision){
		landed();
	}
	
	public void jump(){
		// If the character isnt jumping ... ¡Jump!
		if ( isJumping == false && hasJumping == true) {
			isJumping = true;
			gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
		// If the character can jump two times and isnt jump for second time
		}else if(isDoubleJumping == false && hasDoubleJumping == true){
			isDoubleJumping = true;
			gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
		}
	}

	// Method that decreases the character fall velocity
	public void slowFall(){
		if((hasDoubleJumping == true && isDoubleJumping == true && hasSlowFall == true) || 
		   (hasDoubleJumping == false && hasJumping == true && isJumping == true && hasSlowFall == true)){
			GetComponent<Rigidbody>().drag = 5.0f;
		}
	}

	// Method that increases the character fall velocity
	public void normalFall(){
		if(hasSlowFall == true){
			GetComponent<Rigidbody>().drag = 0.0f;
		}
	}

	// Method that reboot the params when character is landed
	private void landed(){
		isJumping = false;
		isDoubleJumping = false;
	}
} 