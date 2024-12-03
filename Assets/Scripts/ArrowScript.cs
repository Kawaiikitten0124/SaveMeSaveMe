using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public float damageAmount = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Dragon")
        {
            collider.GetComponent<Dragonshooting>().TakeDamage(damageAmount);
             Debug.Log("dragon hit");
            Destroy(gameObject);
        }

        if (collider.gameObject.tag == "Goblin")
        {
            collider.GetComponent<Enemy>().TakeDamage(damageAmount);
            Debug.Log("goblin hit");
            Destroy(gameObject);
        }


    }


}
