using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed= 3.0f;
    private Rigidbody2D enemyRb;
    private GameObject player;
    public float horizontalInput;
    public int totalHealth = 10;
    public int damageAmount;
    public Slider healthSlider;
    public float goblinHealth;
   

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
       
        healthSlider.maxValue = totalHealth;
        healthSlider.value = goblinHealth;
    }

    // Update is called once per frame
    void Update()
    {
        enemyRb.AddForce((player.transform.position - transform.position) * speed);
        if (transform.position.x < -7)
        {
            transform.position = new Vector3(-7, transform.position.y, transform.position.z);
        }


        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed, Space.World);

        if (horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        healthSlider.value = goblinHealth;
    }


    public void TakeDamage(float damageToTake)
    {
     goblinHealth -= damageToTake;
        if (goblinHealth <= 0)
        {
            Destroy(gameObject);
        }

        healthSlider.value = goblinHealth;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<PlayerController>().playerHealth -= damageAmount;
        }
    }

}
