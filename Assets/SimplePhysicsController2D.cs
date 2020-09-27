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

    // Update is called once per frame
    void Update()
    {

        
        if (groundCheckScript.isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                thisRigidbody2D.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            }

            thisRigidbody2D.gravityScale = gravityOnGround;
        }

        else if (groundCheckScript.isGroundedBounce == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                thisRigidbody2D.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
            }

            thisRigidbody2D.gravityScale = gravityOnGround;
        }

        if (groundCheckScript.isGrounded == false)
        {
            thisRigidbody2D.gravityScale = gravityInAir;
        }

        if (groundCheckScript.isGroundedBounce == false)
        {
            thisRigidbody2D.gravityScale = gravityInAir;
        }
    }

    void FixedUpdate()
    {
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
