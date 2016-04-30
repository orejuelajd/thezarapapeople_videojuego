using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WorldSelector : MonoBehaviour {

	// This stores the layers we want the raycast to hit (make sure this GameObject's layer is included!)
	public LayerMask LayerMask = UnityEngine.Physics.DefaultRaycastLayers;
	
	//Start Method	
	void Start(){

	}
	
	//Events need for the Lean Touch
	protected virtual void OnEnable()
	{
		// Hook into the OnFingerTap event
		Lean.LeanTouch.OnFingerTap += OnFingerTap;
	}
	
	protected virtual void OnDisable()
	{
		// Unhook into the OnFingerTap event
		Lean.LeanTouch.OnFingerTap -= OnFingerTap;
	}

	//Method while tap or selecting the character
	public void OnFingerTap(Lean.LeanFinger finger)
	{
		// Does the prefab exist?
		// Make sure the finger isn't over any GUI elements
		if (finger.IsOverGui == false)
		{
			var ray = finger.GetRay();
			var hit = default(RaycastHit);
			
			// Was this finger pressed down on a collider?
			if (Physics.Raycast(ray, out hit, float.PositiveInfinity, LayerMask) == true)
			{
				// The collider is the player1 zarapa boy
				if (hit.collider.gameObject.name == "islandWorld"){
					PlayerPrefs.SetString("world","island");
					Application.LoadLevel("islandLevels");
				}
				// The collider is the player2 zarapa girl
				else if(hit.collider.gameObject.name == "secondWorld"){
					PlayerPrefs.SetString("world","second");
					//Application.LoadLevel("secondLevels");
					Debug.Log("Este mundo aun se encuentra bloqueado");
				}

				else if(hit.collider.gameObject.name == "thirdWorld"){
					PlayerPrefs.SetString("world","third");
					//Application.LoadLevel("thirdLevels");
					Debug.Log("Este mundo aun se encuentra bloqueado");
				}
			}		
		}
	}	
}