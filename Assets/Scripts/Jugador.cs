using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Jugador : MonoBehaviour
{
    private string direction;

    private Vector3 startPositionSwipe;
    private Vector3 endPositionSwipe;
    private Vector3 swipe_;

    public Animator animPlayer;

    //public ButtonController actualButton;

    public GameObject punio;
    private bool moveCollider;
    private Vector3 punio_startPosition;
    private Vector3 offset;

    public float velocidad;
    void Start()
    {
        moveCollider = false;
        animPlayer = this.GetComponent<Animator>();
        punio = this.transform.GetChild(0).gameObject;
        punio_startPosition = punio.transform.position;
    }
    private void Update()
    {
        /*if (actualButton != null)
        {
            punio.gameObject.SetActive(true);
            punio.transform.position = Vector3.Lerp(punio.transform.position, actualButton.offsetPos, velocidad*Time.deltaTime);
        }
        else 
        {
            punio.gameObject.SetActive(false);
            punio.transform.position = Vector3.Lerp(punio.transform.position, punio_startPosition, velocidad * Time.deltaTime);
        }*/


        if (moveCollider)
        {
            punio.gameObject.SetActive(true);
            punio.transform.position = Vector3.Lerp(punio.transform.position, offset, velocidad * Time.deltaTime);
        }
        else 
        {
            punio.gameObject.SetActive(false);
            punio.transform.position = Vector3.Lerp(punio.transform.position, punio_startPosition, velocidad * Time.deltaTime);
        }


        if (Input.touchCount > 0) 
        {
            Touch touch_ = Input.GetTouch(0);
            switch (touch_.phase)
            {
                case TouchPhase.Began:
                    startPositionSwipe = new Vector2(touch_.position.x, touch_.position.y);
                    break;

                case TouchPhase.Ended:
                    endPositionSwipe = new Vector2(touch_.position.x, touch_.position.y);
                    swipe_ = (endPositionSwipe - startPositionSwipe).normalized;

                    if (swipe_.y > 0 && Mathf.Abs(swipe_.x) < 0.5f) 
                    {
                        offset = punio.transform.position + new Vector3(0, 1.1f, 0);
                        direction = "back_t";
                    }

                    else if(swipe_.y < 0 && Mathf.Abs(swipe_.x) < 0.5f)
                    {
                        offset = punio.transform.position + new Vector3(0, -1.1f, 0);
                        direction = "front_t";
                    }

                    else if(swipe_.x < 0 && Mathf.Abs(swipe_.y) < 0.5f)
                    {
                        offset = punio.transform.position + new Vector3(-1.1f, 0, 0);
                        direction = "left_t";
                    }

                    else if (swipe_.x > 0 && Mathf.Abs(swipe_.y) < 0.5f)
                    {
                        offset = punio.transform.position + new Vector3(1.1f, 0, 0);
                        direction = "right_t";
                    }
                    else 
                    {

                    }
                    AnimationBehaviourTrigger(direction);
                    StartCoroutine(moveColliderFunction());
                    direction = direction.Replace("_t", "");
                    UI.instance.updateDirection(direction);
                    break;
            }
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
    
    public void AnimationBehaviourTrigger(string input) 
    {
        animPlayer.SetTrigger(input);
    }

    IEnumerator moveColliderFunction()
    {
        moveCollider = true;
        yield return new WaitForSeconds(0.25f);
        moveCollider = false;
    }

}

