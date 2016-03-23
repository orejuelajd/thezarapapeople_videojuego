using UnityEngine;
using System.Collections;

public class Falling_Plataforms : MonoBehaviour {
	
	private Rigidbody bodyPlataform;
	private Vector3 initPosPlataform;
	private Quaternion initRotPlataform;
	
	
	
	
	// Use this for initialization
	void Start () {
		this.bodyPlataform=GetComponent<Rigidbody>();
		this.initPosPlataform = this.transform.position;
		this.initRotPlataform = this.transform.rotation;

		
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider obj) {

		//Aqui se corrige un Bug, de las plataformas (Bug de que las plataformas rotan un poco y complican todo)
		this.bodyPlataform.freezeRotation = true;

		if (obj.gameObject.CompareTag("Player")) {
			StartCoroutine(fallPlataform ());
		}
		
	}
	
	IEnumerator fallPlataform(){
		// Le decimos que espere 1/2 de segundo antes de caerse
		
		yield return new WaitForSeconds (0.5f);
		this.bodyPlataform.useGravity = true;
		this.bodyPlataform.isKinematic = false;
		
		// inica la Corrutina de devolver el bloque a su posici{on inicial
		
		StartCoroutine (resetPlataformPosition());
	}
	
	IEnumerator resetPlataformPosition(){
		//espero 2 segundos para devolver a la posicion inicial a la plataforma
		yield return new WaitForSeconds (2.0f);
		
		this.bodyPlataform.useGravity = false;
		
		
		// Detenemos la velocidad del bloque completamente porque le vamos a manipular la posicion y la rotacion
		this.bodyPlataform.velocity = Vector3.zero;
		
		this.bodyPlataform.MovePosition(this.initPosPlataform);
		this.bodyPlataform.MoveRotation(this.initRotPlataform);
		
		
		
	}
}
