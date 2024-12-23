using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float forwardInput;
    public float horizontalInput;
    public float speed = 10.0f;
    private Rigidbody2D playerRb;
    public float jumpForce = 1;
    public float gravityModifier;
    public GameObject projectilePrefab;
    private bool isOnGround = true;
    public bool canshoot = true;
    public float shootCoolDown;
    public int totalHealth = 100;
    //public int currentHealth;
    public Slider healthSlider;
    public float playerHealth;
    public int damageAmount;
    public bool hasHealthPotion;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
      playerRb = GetComponent<Rigidbody2D>();
        playerHealth = totalHealth;

        healthSlider.maxValue = totalHealth;
        healthSlider.value = playerHealth;

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        //player movement and keep in bounds
        if(transform.position.x < -7)
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


        // forwardInput = Input.GetAxis("Vertical");
        // transform.Translate(Vector3.up * Time.deltaTime * speed * forwardInput);


        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse); 
            isOnGround = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && canshoot)
        {
            //arrow shoot
            Instantiate(projectilePrefab, transform.position, transform.rotation);
            StartCoroutine(Cooldown());
            
        }

        //if (currentHealth <1)
       // {
           // gameObject.SetActive(false);
           // Destroy(gameObject);
        //}
        healthSlider.value = playerHealth;
    }
    //health 
    public void TakeDamage(float damageToTake)
    {
        playerHealth -= damageToTake;
        if (playerHealth <= 0)
        {
            gameManager.GameOver(false);
            Destroy(gameObject);
          
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        isOnGround = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HealthPotion"))
        {
            hasHealthPotion = true;
            Destroy(collision.gameObject);

            playerHealth = totalHealth;
        }

    }

    //shooting arrow cooldown
    IEnumerator Cooldown()
    { 
     canshoot = false;
        yield return new WaitForSeconds(shootCoolDown);
        canshoot = true;
    }


}



