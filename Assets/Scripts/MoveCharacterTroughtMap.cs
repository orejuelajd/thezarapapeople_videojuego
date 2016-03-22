using UnityEngine;
using System.Collections;

public class MoveCharacterTroughtMap : MonoBehaviour {

	// List that contains all the points that represents the levels
	public GameObject[] levels;
	// Current level in which the character is stand
	private int currentLevel = 0;
	// The speed for move to level A to level B
	private float speed = 90f;
	// The lenght of step to translate the gameobject
	private float step = 0;

	void Start () {
		
	}

	void Update () {
		moveCharacter();
	}

	// The function of this method is update the character's position in the diferents levels of the map
	private void moveCharacter(){
		step = speed * Time.deltaTime;
		if(levels.Length > 0){
			transform.position = Vector3.MoveTowards(transform.position, levels[currentLevel].transform.position, step);
		}
	}

	// This method works when you press "Next Level" button to pass to Level A to Level B
	public void nextLevel(){
		if(currentLevel < levels.Length - 1){
			currentLevel ++;
		}
	}

	// This method works when you press "Previous Level" button to pass to Level B to Level A
	public void previousLevel(){
		if(currentLevel > 0){
			currentLevel --;
		}
	}

	// When you choose a level to play, the level selected will be loaded in the next scene
	public void selectLevel(){
		PlayerPrefs.SetInt("levelSelected", currentLevel);
		Application.LoadLevel("level"+currentLevel);
	}
}