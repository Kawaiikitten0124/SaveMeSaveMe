using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
      playerRb = GetComponent<Rigidbody2D>();
     // Physics2D.gravity *= gravityModifier;
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
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);


       // forwardInput = Input.GetAxis("Vertical");
       // transform.Translate(Vector3.up * Time.deltaTime * speed * forwardInput);


        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse); 
            isOnGround = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            //arrow shoot
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOnGround = true;
    }



}



