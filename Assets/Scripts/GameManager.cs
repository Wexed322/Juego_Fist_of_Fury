using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance_;

    public delegate void PlayerKill();
    public static PlayerKill onPlayerKill;

    public int score;

    private void Start()
    {
        onPlayerKill = kill;
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

    public void kill() 
    {
        score++;
    }
}
