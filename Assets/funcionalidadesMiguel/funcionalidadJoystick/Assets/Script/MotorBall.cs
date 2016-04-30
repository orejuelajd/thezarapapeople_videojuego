using UnityEngine;
using System.Collections;

public class MotorBall : MonoBehaviour {

    public float moveSpeed = 5.0f;
    public float drag = 0.5f;
    public float terminalRotacionSpeed = 25.0f;
    public Vector3 moveVector { set; get;}
    public VirtualJoystick joystick;
   

    private Rigidbody thisRigidBody;

    void Start () {
        thisRigidBody = gameObject.AddComponent<Rigidbody>();
        thisRigidBody.maxAngularVelocity = terminalRotacionSpeed;
        thisRigidBody.drag = drag;
	}
	
	
	void Update () {
        moveVector = poolInput();
        move();
	}

    private void move()
    {
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
