using UnityEngine;
using System.Collections;
using DG.Tweening;

public class MovingPlatform : MonoBehaviour {

	public float xStart, yStart, zStart;
	public float xFinal, yFinal, zFinal;
	public float speed;
	private float duration;

	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (xStart, yStart, zStart);
		StartCoroutine(Moving ());
	}

	IEnumerator Moving(){
		// Start after one second delay (to ignore Unity hiccups when activating Play mode in Editor)
		yield return new WaitForSeconds(1);

		//Calculating the time need
		duration = (Mathf.Sqrt (Mathf.Pow ((xFinal - xStart), 2) + Mathf.Pow ((yFinal - yStart), 2) + 
				                                Mathf.Pow ((zFinal - zStart), 2)))/speed;
		Debug.Log (duration);

		// Create a new Sequence.
		Sequence s = DOTween.Sequence();
		s.Append(transform.DOMove(new Vector3(xFinal,yFinal,zFinal), duration));
		s.SetLoops(-1,LoopType.Yoyo);
	}
	
	// Update is called once per frame
	void Update () {


	}
}
