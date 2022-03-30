using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance_;
    private int score;
    private void Awake()
    {
        if (GameManager.instance_ == null)
        {
            GameManager.instance_ = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
        
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
