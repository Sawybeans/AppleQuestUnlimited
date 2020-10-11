using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded;
    public bool isGroundedBounce;
    public bool isGroundedGrav;

    public void OnTriggerEnter2D(Collider2D other)
    {

        print(other.gameObject.name);
        if (other.gameObject.CompareTag("Ground")) 
        {
            isGrounded = true;
        }

        else if (other.gameObject.CompareTag("Bounce"))
        {
            isGroundedBounce = true;
        }

        else if (other.gameObject.CompareTag("Gravity"))
        {
            isGroundedGrav = true;
        }

        else
        {
            isGrounded = false;
            isGroundedBounce = false;
            isGroundedGrav = false;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        //I seriously have no idea what is preventing this from working properly, I feel like I've done everything right on this front

        if (other.gameObject.CompareTag("Bounce"))
        {
            isGrounded = false;
        }

        else if (other.gameObject.CompareTag("Ground"))
        {
            isGroundedBounce = false;
        }

        else if (other.gameObject.CompareTag("Gravity"))
        {
            isGroundedGrav = false;
        }
    }

}
