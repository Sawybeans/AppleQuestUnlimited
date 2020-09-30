using UnityEngine;

public class SimplePhysicsController2D : MonoBehaviour
{

    public SpriteRenderer thisSprite;
    public Rigidbody2D thisRigidbody2D;
    public float force = 10f;
    public float bounceForce = 70f;

    public GroundCheck groundCheckScript;
    public EndingInit ending;

    public float gravityInAir;
    public float gravityOnGround;

    public float maxDistance = 1f;
    public float gravityWell;

    public bool overWell = false;

    // Update is called once per frame
    void Update()
    {
        
        //If the player is on the ground
        if (groundCheckScript.isGrounded == true)
        {
            
            //If the player presses space, increase the upward velocity by the set jump speed
            if (Input.GetKeyDown(KeyCode.Space))
            {
                thisRigidbody2D.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            }

            //If the player is over a gravity well, increase the gravity
            if (overWell == true){
                thisRigidbody2D.gravityScale = gravityWell;
            }

            //Otherwise, use normal gravity
            else { 
                thisRigidbody2D.gravityScale = gravityOnGround; 
            }
            
        }

        else if (groundCheckScript.isGroundedBounce == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                thisRigidbody2D.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
            }

            if (overWell == true)
            {
                thisRigidbody2D.gravityScale = gravityWell;
            }

            else
            {
                thisRigidbody2D.gravityScale = gravityOnGround;
            }
        }

        else if (groundCheckScript.isGroundedGrav == true)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                thisRigidbody2D.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            }

            if (overWell == true)
            {
                thisRigidbody2D.gravityScale = gravityWell;
            }

            else
            {
                thisRigidbody2D.gravityScale = gravityOnGround;
            }

        }

        //Same with in-air
        if (groundCheckScript.isGrounded == false)
        {
            if (overWell == true)
            {
                thisRigidbody2D.gravityScale = gravityWell;
            }

            else
            {
                thisRigidbody2D.gravityScale = gravityInAir;
            }
        }

        if (groundCheckScript.isGroundedBounce == false)
        {
            if (overWell == true)
            {
                thisRigidbody2D.gravityScale = gravityWell;
            }

            else
            {
                thisRigidbody2D.gravityScale = gravityInAir;
            }
        }

        if (groundCheckScript.isGroundedGrav == false)
        {
            if (overWell == true)
            {
                thisRigidbody2D.gravityScale = gravityWell;
            }

            else
            {
                thisRigidbody2D.gravityScale = gravityInAir;
            }
        }
    }

    void FixedUpdate()
    {

        //Determine whether or not the player is above a gravity well using a raycast
        //If true, set gravity above to gravityWell, if false leave it as is

        Ray myRay = new Ray(transform.position, Vector2.down);
        Debug.DrawRay(myRay.origin, myRay.direction, Color.white);

        if (Physics2D.Raycast(myRay.origin, myRay.direction, maxDistance))
        {
            overWell = true;
        }
        else
        {
            overWell = false;
        }

        
        //Left and right inputs

        if (Input.GetKey(KeyCode.D))
        {
            thisRigidbody2D.AddForce(Vector2.right * force * Time.fixedDeltaTime, ForceMode2D.Impulse);

            if (thisSprite.flipX == false)
            {
                thisSprite.flipX = true;
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            thisRigidbody2D.AddForce(-Vector2.right * force * Time.fixedDeltaTime, ForceMode2D.Impulse);

            if (thisSprite.flipX == true)
            {
                thisSprite.flipX = false;
            }
        }
    }


}
