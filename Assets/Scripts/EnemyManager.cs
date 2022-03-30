using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [Header("EnemyController")]
    [SerializeField] List<GameObject> enemies;

    [SerializeField] int coolDownSpawnMin;
    [SerializeField] int coolDownSpawnMax;
    [SerializeField] int coolDownSpawn;

    [SerializeField] bool boolSpawn;
    void Start()
    {
        coolDownSpawn = Random.Range(coolDownSpawnMin, coolDownSpawnMax);
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

            coolDownSpawn = Random.Range(coolDownSpawnMin, coolDownSpawnMax);
            int indiceE = Random.Range(0, enemies.Count);
            Instantiate(enemies[indiceE], enemies[indiceE].transform.position, enemies[indiceE].transform.rotation);
            boolSpawn = false;
        }
    }
}
