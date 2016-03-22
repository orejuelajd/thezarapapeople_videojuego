using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour {
	
	//Region de Variables Privadas
	
	[SerializeField]
	private float distanceAway;
	[SerializeField]
	private float distanceUp;
	[SerializeField]
	private float smooth;
	[SerializeField]
	private Transform followCharacter;
	private Vector3 targetPosition;
	
	
	// Use this for initialization
	void Start () {
		
		
		followCharacter = GameObject.FindWithTag("Player").transform;
		
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	void LateUpdate(){
		
		//Ajuste de la posicion del jugador, para que el desplazamiento  de la camara sea el correcto
		
		targetPosition = followCharacter.position + (followCharacter.up * distanceUp) - (followCharacter.forward * distanceAway);
		Debug.DrawRay (followCharacter.position, Vector3.up * distanceUp, Color.red);
		Debug.DrawRay (followCharacter.position,-1f*followCharacter.forward*distanceAway,Color.blue);
		Debug.DrawLine(followCharacter.position, targetPosition, Color.magenta);
		
		
		
		//Haciendo una translacion suave entre la posición actual de la camara y la posición en la que estara
		//Interpolacion entre los dos vectores de posicion del jugador
		
		transform.position = Vector3.Lerp (transform.position, targetPosition, Time.deltaTime*smooth);
		
		
		//Nos aseguramos de que la camara esta mirando en el lado correcto, es decir mirando al personaje
		
		transform.LookAt (followCharacter);
		
		
		
		
	}
	
}