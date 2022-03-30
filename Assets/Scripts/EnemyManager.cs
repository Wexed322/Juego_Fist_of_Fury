using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [Header("EnemyController")]
    [SerializeField] List<GameObject> enemies;
    [SerializeField] float coolDownSpawn;
    [SerializeField] bool boolSpawn;
    void Start()
    {
        boolSpawn = false;
    }

    void Update()
    {
        StartCoroutine(spawnEnemies());
    }

    IEnumerator spawnEnemies() 
    {
        if (!boolSpawn) 
        {
            boolSpawn = true;
            yield return new WaitForSecondsRealtime(coolDownSpawn);
            boolSpawn = false;
            int indiceE = Random.Range(0, enemies.Count);
            Debug.Log(indiceE);
            Instantiate(enemies[indiceE], enemies[indiceE].transform.position, enemies[indiceE].transform.rotation);
        }
    }
}
