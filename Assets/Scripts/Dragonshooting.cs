using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dragonshooting : MonoBehaviour
{

    public GameObject fireball;
    public Transform fireballPos;
    public int damageAmount;
    public int totalHealth = 100;
    //public int currentHealth;
    public Slider healthSlider;
    public float dragonHealth;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        healthSlider.maxValue = totalHealth;
        healthSlider.value = dragonHealth;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 6)
        {
            timer = 0;
            shoot();
        }
    }

    void shoot()
    {
        Instantiate(fireball, fireballPos.position, Quaternion.identity);
    }

    public void TakeDamage(float damageToTake)
    { 
     dragonHealth -= damageToTake;
        if (dragonHealth <= 0)
        {
            Destroy(gameObject);
        }

        healthSlider.value = dragonHealth;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<PlayerController>().playerHealth -= damageAmount;
        }
    }
}


