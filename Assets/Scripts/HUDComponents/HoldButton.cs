using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	// Function to execute when user press hold the button
	public UnityEvent eventHold;
	// Funtion to execute when user drops the button
	public UnityEvent eventDrop;
	
	void Start () {
	
	}

	void Update () {
	
	}

	// Function to execute when user press hold the button
	public void OnPointerDown (PointerEventData eventData) {
		eventHold.Invoke();
	}

	// Funtion to execute when user drops the button
	public void OnPointerUp (PointerEventData eventData) {
		eventDrop.Invoke();
	}

}
