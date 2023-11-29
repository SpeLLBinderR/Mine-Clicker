using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Spawning;
    private int spawnRangeX= -800;
    public int spawnDownRangeY = 180, spawnTopRangeY = 240 ;

    void Start()
    {
        InvokeRepeating("Spawn_Cloud", 7, 7.5f);
    }

    void Spawn_Cloud()
    {
        Vector3 spawnPos = new Vector3(spawnRangeX, Random.Range(spawnDownRangeY, spawnTopRangeY), 0);
        Instantiate(Spawning, spawnPos, Spawning.transform.rotation);
        transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
    }
}
