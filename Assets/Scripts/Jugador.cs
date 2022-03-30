using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Jugador : MonoBehaviour
{
    [SerializeField] List<Button> botones;
    [SerializeField] float velocidadRot;
        
    void Start()
    {
        botones[0].onClick.AddListener(() => RotationCharacter(new Vector3(0, 0, 0)));
        botones[1].onClick.AddListener(() => RotationCharacter(new Vector3(0, 180, 0)));
        botones[2].onClick.AddListener(() => RotationCharacter(new Vector3(0, 0, 90)));
        botones[3].onClick.AddListener(() => RotationCharacter(new Vector3(0, 0, -90)));
    }
    public void RotationCharacter(Vector3 to) 
    {
        transform.rotation = Quaternion.Euler(to);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(collision.gameObject);
            GameManager.onPlayerKill?.Invoke();
        }
    }

}

