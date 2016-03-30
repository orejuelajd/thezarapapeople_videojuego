using UnityEngine;
using System.Collections;

public class InitializeTextureSelection : MonoBehaviour {

	string gender;
	
	public void initialize(){
		
		gender = PlayerPrefs.GetString("gender");
		
		if (gender.Equals ("man")) {
			Application.LoadLevel("selectManAppearance");
		}
		
		if (gender.Equals ("woman")) {
			Application.LoadLevel("selectWomanAppearance");
		}
	}
}
