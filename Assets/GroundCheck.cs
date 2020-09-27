using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded;
    public bool isGroundedBounce;
    public Object canCollide;

    public void OnTriggerStay2D(Collider2D other)
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
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }

        if (other.gameObject.CompareTag("Bounce"))
        {
            isGrounded = false;
        }
    }
}
