using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject spawnedEnemy;
    public float timeToSpawn, spawnCountdown;
    // Start is called before the first frame update
    void Start()
    {
        spawnCountdown = timeToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        spawnCountdown -= Time.deltaTime;

        if (spawnCountdown <= 0)
        {
            spawnCountdown = timeToSpawn;

            Instantiate(spawnedEnemy, transform.position, transform.rotation);
        }
    }
}
