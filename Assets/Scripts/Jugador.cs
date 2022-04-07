using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Jugador : MonoBehaviour
{
    public Animator animPlayer;

    public ButtonController actualButton;

    public GameObject punio;
    private Vector3 punio_startPosition;

    public float velocidad;
    void Start()
    {
        animPlayer = this.GetComponent<Animator>();
        punio = this.transform.GetChild(0).gameObject;
        punio_startPosition = punio.transform.position;
    }
    private void Update()
    {
        if (actualButton != null)
        {
            punio.gameObject.SetActive(true);
            punio.transform.position = Vector3.Lerp(punio.transform.position, actualButton.offsetPos, velocidad*Time.deltaTime);
        }
        else 
        {
            punio.gameObject.SetActive(false);
            punio.transform.position = Vector3.Lerp(punio.transform.position, punio_startPosition, velocidad * Time.deltaTime);
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

    public void AnimationBehaviour(string input, bool yon) 
    {
        animPlayer.SetBool(input, yon);
    }

}

