using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemyEvent 
{
    public static System.Action eventoMuerteEnemy;

    /*public static System.Action<string, string, string> eventoMuerteString;//eventoConparametros*/
}
public class GameManager : MonoBehaviour
{
    public static GameManager instance_;
    public int score;

    /*public delegate void PlayerKill(int a, int b, string eaaaa);//DELEGATE CON PARAMETROS
    public static PlayerKill onPlayerKill;//DELEGATE CON PARAMETROS*/

    private void Start()
    {

    }
    private void Awake()
    {
        if (instance_ == null)
        {
            instance_ = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
        
    }

}

