using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Jugador : MonoBehaviour
{
    [SerializeField] List<Button> botones;
    [SerializeField] float velocidadRot;



    [SerializeField] TextMeshProUGUI texto;
        
    void Start()
    {
        botones[0].onClick.AddListener(() => RotationCharacter(new Vector3(0, 0, 0)));
        botones[1].onClick.AddListener(() => RotationCharacter(new Vector3(0, 180, 0)));
        botones[2].onClick.AddListener(() => RotationCharacter(new Vector3(0, 0, 90)));
        botones[3].onClick.AddListener(() => RotationCharacter(new Vector3(0, 0, -90)));
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void RotationCharacter(Vector3 to) 
    {
        transform.rotation = Quaternion.Euler(to);
    }

    public void PrintName(Button a) 
    {
        texto.text = a.gameObject.name.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log("sad");
            Destroy(collision.gameObject);
        }
    }
}
