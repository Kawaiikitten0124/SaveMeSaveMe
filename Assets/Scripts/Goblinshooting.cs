using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblinshooting : MonoBehaviour
{

    public GameObject goblinAxe;
    public Transform goblinAxePos;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 3)
        {
            timer = 0;
            shoot();
        }
    }

    void shoot()
    {
        Instantiate(goblinAxe, goblinAxePos.position, Quaternion.identity);
    }
}
