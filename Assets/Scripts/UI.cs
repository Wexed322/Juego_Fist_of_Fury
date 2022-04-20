using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    public static UI instance;
    public TextMeshProUGUI direccion;
    public TextMeshProUGUI scoreText;
    void Start()
    {
        instance = this;
        KillEnemyEvent.eventoMuerteEnemy += updateScore;


        //GameManager.onPlayerKill = debugDelegateWtf;//DELEGATE CON PARAMETROS
    }

    public void updateScore() 
    {
        GameManager.instance_.score++;
        scoreText.text = GameManager.instance_.score.ToString() + " Kills";
    }

    public void updateDirection(string text_)
    {
        direccion.text = text_;
    }


    /*public void debugDelegateWtf(int a, int b, string c)//DELEGATE CON PARAMETROS, puede ser devolver void u otra cosa
    {
        Debug.Log("sd");
    }*/
}
