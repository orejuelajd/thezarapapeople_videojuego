using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextureSelector : MonoBehaviour {

	public GameObject player;
	public Button texture1, texture2, texture3;
	public Texture character1, character2, character3;
	Renderer player_renderer;
	public string gender;


	void OnEnable()
	{
		player_renderer = player.GetComponent<Renderer>();
		texture1.onClick.AddListener(delegate{changeAppearance(1);});
		texture2.onClick.AddListener(delegate{changeAppearance(2);});
		texture3.onClick.AddListener(delegate{changeAppearance(3);});
	}

	void changeAppearance(int texture)
	{
		if(texture==1){
			player_renderer.material.mainTexture= character1;
			PlayerPrefs.SetString("textura",gender+""+texture);
		}
		if(texture==2){
			player_renderer.material.mainTexture= character2;
			PlayerPrefs.SetString("textura",gender+""+texture);
		}
		if(texture==3){
			player_renderer.material.mainTexture= character3;
			PlayerPrefs.SetString("textura",gender+""+texture);
		}

	}
}
