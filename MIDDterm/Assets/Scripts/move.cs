using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
{
// variables for the code
    public float speed = 9f;
    public float xBorder = 110f; 
    private Rigidbody2D rb2d;
    public float jumpForce = 500f; 
   bool grounded; 

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        var velocity = rb2d.velocity;  
 
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) && transform.position.x <= xBorder) 
        {
         velocity.x = speed;         
         Debug.Log ("D");
         Debug.Log ("RightArrow");
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) && transform.position.x >= -xBorder) 
        {
            velocity.x = -speed;    
             Debug.Log ("A");
             Debug.Log ("LeftArrow");
        }
    
        else {                 
        velocity.x = 0;         
        }
  
     if (Input.GetKeyDown(KeyCode.Space) && grounded) 
    
        {
         rb2d.AddForce(new Vector2(rb2d.velocity.x, jumpForce));
        }
     if (Input.GetKeyUp(KeyCode.Space) && rb2d.velocity.y > 0f)
     {
        rb2d.AddForce(new Vector2(rb2d.velocity.x, jumpForce * 0.15f));
     }
  
     rb2d.velocity = velocity;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Vector2 normal = other.GetContact(0).normal;
            if (normal == Vector2.up)
            {
                grounded = true;
            }
        }  
    }
    void OnCollisionExit2D(Collision2D other)
     {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }

    }
}



