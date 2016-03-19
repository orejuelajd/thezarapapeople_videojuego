using UnityEngine;
using System.Collections;

public class MoveCharacterTroughtMap : MonoBehaviour {

	public GameObject[] levels;
	private int currentLevel = 0;
	private float speed = 90f;

	void Start () {
		
	}

	void Update () {
		//transform.position = Vector3.Lerp(transform.position, new Vector3(levels[currentLevel].transform.position.x * speed, levels[currentLevel].transform.position.y * speed, 0), 0),
		float step = speed * Time.deltaTime;
		if(levels.Length > 0){
			transform.position = Vector3.MoveTowards(transform.position, levels[currentLevel].transform.position, step);
		}
		Debug.Log(currentLevel);
	}

	public void nextLevel(){
		if(currentLevel < levels.Length - 1){
			currentLevel ++;
		}
	}

	public void previousLevel(){
		if(currentLevel > 0){
			currentLevel --;
		}
	}

	public void selectLevel(){
		PlayerPrefs.SetInt("levelSelected", currentLevel);
		Application.LoadLevel("level"+currentLevel);
	}
}