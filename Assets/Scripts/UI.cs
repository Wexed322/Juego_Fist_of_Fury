using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    public static UI instanceUI;
    [SerializeField] TextMeshProUGUI direccion;
    [SerializeField] TextMeshProUGUI scoreText;
    void Start()
    {
        instanceUI = this;
        GameManager.onPlayerKill += updateScore;
    }

    void Update()
    {
        
    }
    public void PrintName(Button a)
    {
        direccion.text = a.gameObject.name.ToString();
    }
    public void updateScore() 
    {
        scoreText.text = GameManager.instance_.score.ToString() + " Kills";
    }
}
