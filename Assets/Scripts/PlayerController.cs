using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float mySpeedX;
    private float mySpeedY;
    [SerializeField] float speed;
    private Rigidbody2D myRigidbody;
    [SerializeField] int jumpForce;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        jumpForce = 2;

    }

    // Update is called once per frame
    void Update()
    {
        
        mySpeedX = Input.GetAxis("Horizontal");//-1 1 arasýnda deðer verir
        mySpeedY = Input.GetAxis("Vertical");
        myRigidbody.velocity = new Vector2(mySpeedX * speed, myRigidbody.velocity.y);
        jump();

    }

    private void jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            myRigidbody.AddForce(Vector2.up * jumpForce);
        }
        

    }
}
