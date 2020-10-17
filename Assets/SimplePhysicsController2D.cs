using UnityEngine;

public class SimplePhysicsController2D : MonoBehaviour
{

    public SpriteRenderer thisSprite;
    public Rigidbody2D thisRigidbody2D;
    public float force = 10f;
    public float bounceForce = 70f;

    public AudioSource jumpSound;

    public GroundCheck groundCheckScript;
    public EndingInit ending;

    //Gravity variables
    public float gravityInAir;
    public float gravityOnGround;

    //Gravity well raycast variables
    public float maxDistance = 1f;
    public float gravityWell;

    //Ground raycast variables
    public LayerMask myLayerMask;
    public LayerMask groundMask;
    public float groundDist = 1f;

    //Various ground checks
    public bool overWell = false;
    public bool onBounce = false;
    public bool onGround = false;
    public bool onWell = false;
    public bool canJump = false;

    // Update is called once per frame
    void Update()
    {

        //If the player can jump, then jump
        if (canJump == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (onBounce == false)
                {
                    thisRigidbody2D.AddForce(Vector2.up * force, ForceMode2D.Impulse);
                    jumpSound.pitch = (Random.Range(.85f, 1.3f));
                    jumpSound.Play();
                }

                if (onBounce == true)
                {
                    thisRigidbody2D.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
                    jumpSound.pitch = (Random.Range(.85f, 1.3f));
                    jumpSound.Play();
                }
            }
        }

        //Set various gravity instances
        if (overWell == true)
        {
            thisRigidbody2D.gravityScale = gravityWell;
        }

        if (overWell == false && onGround == true)
        {
            thisRigidbody2D.gravityScale = gravityOnGround;
        }

        if (overWell == false && onGround == false)
        {
            thisRigidbody2D.gravityScale = gravityInAir;
        }

    }
    
    void FixedUpdate()
    {
        

        //Determine whether or not the player is on top of a platform using a raycast
        //If true, player can jump, otherwise the player cannot jump

        Ray groundRay = new Ray(transform.position, Vector2.down);
        Debug.DrawRay(groundRay.origin, groundRay.direction, Color.red);

        RaycastHit2D grounded = Physics2D.Raycast(groundRay.origin, groundRay.direction, groundDist, groundMask);

        if (Physics2D.Raycast(groundRay.origin, groundRay.direction, groundDist))
        {
            if (grounded.collider != null)
            {
                if (grounded.collider.gameObject.CompareTag("Ground"))
                {
                    onGround = true;
                    onBounce = false;
                    onWell = false;
                    canJump = true;
                }

                if (grounded.collider.gameObject.CompareTag("Bounce"))
                {
                    onGround = false;
                    onBounce = true;
                    onWell = false;
                    canJump = true;
                }

                if (grounded.collider.gameObject.CompareTag("Gravity"))
                {
                    onGround = false;
                    onBounce = false;
                    onWell = true;
                    canJump = true;
                }

            }

            else
            {
                onBounce = false;
                onGround = false;
                onWell = false;
                canJump = false;
            }
        }

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
