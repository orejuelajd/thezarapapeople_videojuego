using UnityEngine;
using System.Collections;

public class MotorBall : MonoBehaviour {

    public float moveSpeed = 0.0f;
    public float drag = 0.0f;
    public float terminalRotacionSpeed = 0.0f;
    public Vector3 moveVector { set; get;}
    public VirtualJoystick joystick;
   

    private Rigidbody thisRigidBody;

    void Start () {
        thisRigidBody = gameObject.GetComponent<Rigidbody>();
        thisRigidBody.drag = drag;
	}
	
	
	void Update () {
		moveVector = poolInput();
		move();
	}

	void FixedUpdate(){

	}

    private void move(){
        thisRigidBody.AddForce((moveVector * moveSpeed));
    }

    private Vector3 poolInput()
    {
        Vector3 dir = Vector3.zero;

        dir.x = joystick.Horizontal();
        dir.z = joystick.Vertical();

        if (dir.magnitude > 1)
            dir.Normalize();
        return dir;
    }
}
