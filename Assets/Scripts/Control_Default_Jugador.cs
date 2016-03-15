using UnityEngine;
using System.Collections;

public class Control_Default_Jugador : MonoBehaviour {

	public float vel_mov = 0;
	public bool mov_hor = false;
	public bool mov_ver = false;
	public bool mov_runner = false;
	public GameObject carril_izquierdo;
	public GameObject carril_centro;
	public GameObject carril_derecho;
	private GameObject[] carriles = new GameObject[3];
	public bool mueveEntreCarrilesEnX = false;
	public bool mueveEntreCarrilesEnY = false;
	public bool mueveEntreCarrilesEnZ = false;
	public bool salto = false;
	public bool dobleSalto = false;
	public float fuerzaSalto = 500;
	private bool estaSaltando = false;
	private int cont_carril = 0;

	void Start () {
		carriles[0] = carril_izquierdo;
		carriles[1] = carril_centro;
		carriles[2] = carril_derecho;
	}

	void Update () {
		moverPersonaje();
	}

	void moverPersonaje(){
		if(mov_hor){
			transform.Translate(0,0,Input.GetAxis("Horizontal")*vel_mov*Time.deltaTime);
		}
		if(mov_ver){
			transform.Translate(0,Input.GetAxis("Vertical")*vel_mov*Time.deltaTime,0);
		}

	    if (Input.GetButtonDown ("Jump")) {
			Saltar();
		}

		if(Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") > 0){
			DesplazarCarrilDerecha();
		}
		if(Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") < 0){
			DesplazarCarrilIzquierda();
		}
		if(mueveEntreCarrilesEnX){
			mueveEntreCarrilesEnY = false;
			mueveEntreCarrilesEnZ = false;
			transform.position = new Vector3(carriles[cont_carril].transform.position.x, transform.position.y, transform.position.z);
		}

		if(mueveEntreCarrilesEnY){
			mueveEntreCarrilesEnX = false;
			mueveEntreCarrilesEnZ = false;
			transform.position = new Vector3(transform.position.x, carriles[cont_carril].transform.position.y, transform.position.z);
		}

		if(mueveEntreCarrilesEnZ){
			mueveEntreCarrilesEnX = false;
			mueveEntreCarrilesEnY = false;
			transform.position = new Vector3(transform.position.x, transform.position.y, carriles[cont_carril].transform.position.z);
		}
		
	}

	void OnCollisionEnter(Collision collision){
		estaSaltando = false;
	}

	public void Saltar(){
		if ( salto == true && estaSaltando == false) {
			estaSaltando = true;
			gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * fuerzaSalto);
		}
	}

	public void DesplazarCarrilDerecha(){
		if(mov_runner){
			cont_carril ++;
			if(cont_carril >= 2){
				cont_carril = 2;
			}
		}
	}

	public void DesplazarCarrilIzquierda(){
		if(mov_runner){
			cont_carril --;
			if(cont_carril <= 0){
				cont_carril = 0;
			}
		}
	}
} 
