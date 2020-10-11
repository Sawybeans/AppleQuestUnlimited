using UnityEngine;

public class SimplePhysicsController2D : MonoBehaviour
{

    public SpriteRenderer thisSprite;
    public Rigidbody2D thisRigidbody2D;
    public float force = 10f;
    public float bounceForce = 70f;

    public GroundCheck groundCheckScript;
    public EndingInit ending;

    //Gravity variables
    public float gravityInAir;
    public float gravityOnGround;

    //Gravity well raycast variables
    public float maxDistance = 1f;
    public float gravityWell;
    public LayerMask myLayerMask;

    //Various ground checks
    public bool overWell = false;
    public bool onBounce = false;
    public bool onGround = false;
    public bool onWell = false;
    public bool canJump = false;

    // Update is called once per frame
    void Update()
    {
        
        //If the player is on the ground
        if (groundCheckScript.isGrounded == true)
        {
            //Truly baffled by what could be causing this to not work
            onGround = true;
            onBounce = false;
            onWell = false;

            canJump = true;

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

        //Same as the last one, just for the bounce pads
        else if (groundCheckScript.isGroundedBounce == true)
        {

            onGround = false;
            onBounce = true;
            onWell = false;

            canJump = true;

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

        //Same as the last two, just for the gravity wells
        else if (groundCheckScript.isGroundedGrav == true)
        {

            onGround = false;
            onBounce = false;
            onWell = true;

            canJump = true;

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

            onGround = false;
            onBounce = false;
            onWell = false;

            canJump = false;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                thisRigidbody2D.AddForce(Vector2.up * 0, ForceMode2D.Impulse);
            }

            if (overWell == true)
            {
                thisRigidbody2D.gravityScale = gravityWell;
            }

            else
            {
                thisRigidbody2D.gravityScale = gravityInAir;
            }
        }

        //Not on bounce pad
        if (groundCheckScript.isGroundedBounce == false)
        {

            onGround = false;
            onBounce = false;
            onWell = false;

            canJump = false;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                thisRigidbody2D.AddForce(Vector2.up * 0, ForceMode2D.Impulse);
            }

            if (overWell == true)
            {
                thisRigidbody2D.gravityScale = gravityWell;
            }

            else
            {
                thisRigidbody2D.gravityScale = gravityInAir;
            }
        }

        //Not on gravity well
        if (groundCheckScript.isGroundedGrav == false)
        {

            onGround = false;
            onBounce = false;
            onWell = false;

            canJump = false;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                thisRigidbody2D.AddForce(Vector2.up * 0, ForceMode2D.Impulse);
            }

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

        RaycastHit2D hit = Physics2D.Raycast(myRay.origin, myRay.direction, maxDistance, myLayerMask);

        if (Physics2D.Raycast(myRay.origin, myRay.direction, maxDistance))
        {

            if (hit.collider != null && hit.collider.gameObject.CompareTag("Gravity"))
            {
                if (hit.collider.tag == "Gravity")
                {
                    overWell = true;
                }
                
            }
            else
            {
                overWell = false;
            }

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
