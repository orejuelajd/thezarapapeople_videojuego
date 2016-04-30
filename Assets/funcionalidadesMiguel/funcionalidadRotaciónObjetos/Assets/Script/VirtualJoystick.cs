using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    // Se declaran el fondo del joystick, el joystick, el vector que va a tomar la posicion del drag y la posicion del mouse.
    private Image backgroundJoystick;
    private Image joystick;
    private Vector3 joystickVectorPosition;
    private Vector2 positionMouse;

    private void Start()
    {
        //se le da al fondo del joystick los componentes de una imagen y se atacha el joystick al fondo.
        backgroundJoystick = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
    }
    public virtual void OnDrag(PointerEventData ped)
    {
        //se hacen los calculos para sacar la posicion cuando el mouse es presionado.
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle
            (backgroundJoystick.rectTransform, ped.position, ped.pressEventCamera, out positionMouse))
        {
            positionMouse.x = (positionMouse.x/backgroundJoystick.rectTransform.sizeDelta.x);
            positionMouse.y = (positionMouse.y / backgroundJoystick.rectTransform.sizeDelta.y);

            joystickVectorPosition = new Vector3(positionMouse.x * 2 + 1, 0, positionMouse.y * 2 - 1);
            joystickVectorPosition = (joystickVectorPosition.magnitude > 1.0f)? joystickVectorPosition.normalized: joystickVectorPosition;

            // Mueve la imagen del joystick
            joystick.rectTransform.anchoredPosition =
               new Vector3(joystickVectorPosition.x * (backgroundJoystick.rectTransform.sizeDelta.x / 3)
               , joystickVectorPosition.z * (backgroundJoystick.rectTransform.sizeDelta.y / 3));
        }
    }
    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        // cuando se suelta el joystick este se devuelve a su posicion predefinida.
        joystickVectorPosition = Vector3.zero;
        joystick.rectTransform.anchoredPosition = Vector3.zero;
    }

    public float Horizontal()
    {
        if (joystickVectorPosition.x != 0)
            return joystickVectorPosition.x;
        else
            return Input.GetAxis("Horizontal");
    }

    public float Vertical()
    {
        if (joystickVectorPosition.z != 0)
            return joystickVectorPosition.z;
        else
            return Input.GetAxis("Vertical");
    }
}
