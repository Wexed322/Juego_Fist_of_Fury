using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Vector3 offsetPos;
    public string direction;
    //public bool pressed;
    Jugador scriptReference;

    Button botonActual;
    

    void Start()
    {
        scriptReference = FindObjectOfType<Jugador>();
        botonActual = this.GetComponent<Button>();
        offsetPos += scriptReference.transform.position;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        scriptReference.AnimationBehaviour(direction, true);

        //scriptReference.actualButton = this;
        UI.instance.direccion.text = botonActual.gameObject.name;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        scriptReference.AnimationBehaviour(direction, false);

        //scriptReference.actualButton = null;
        UI.instance.direccion.text = "idle";
    }
}
