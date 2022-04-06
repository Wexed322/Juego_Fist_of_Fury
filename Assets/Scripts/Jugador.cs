using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Jugador : MonoBehaviour
{
    public ButtonController actualButton;
        
    void Start()
    {

    }
    private void Update()
    {
        if (actualButton != null) 
        {
            this.gameObject.transform.rotation = Quaternion.Euler(actualButton.rotationForButton);
        }
        else 
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0,0,0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            KillEnemyEvent.eventoMuerteEnemy?.Invoke();
            Destroy(collision.gameObject);
        }
    }

}

