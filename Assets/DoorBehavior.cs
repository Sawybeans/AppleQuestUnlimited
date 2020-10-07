using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{

    public bool atDoor = false;
    public Transform self;
    public Transform door1;
    public Transform door2;
    public Transform door3;
    public Transform door4;
    public Transform door5;
    public Transform door6;
    public Transform door7;
    public Transform door8;
    public Transform door9;
    public Transform door10;
    public Transform dead;

    public Camera camera1;
    public Camera camera2;

    public int lastDoor = 0;
    public GameObject me;
    public EndingInit ending;

    public void Start()
    {
        camera1.enabled = true;
        camera2.enabled = false;
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Door1"))
        {
            atDoor = true;
            print("At door 1");

            if (Input.GetKey(KeyCode.E))
            {
                print("Travel");
                self.transform.position = door2.position;
                lastDoor = 2;
            }

        }

        if (other.gameObject.CompareTag("Door2"))
        {
            atDoor = true;
            print("At door 2");

            if (Input.GetKeyDown(KeyCode.E))
            {
                print("Travel");
                self.transform.position = door1.position;
            }
        }

        if (other.gameObject.CompareTag("Door3"))
        {
            atDoor = true;
            print("At door 3");

            if (Input.GetKey(KeyCode.E))
            {
                print("Travel");
                self.transform.position = door4.position;
                lastDoor = 4;
            }
        }

        if (other.gameObject.CompareTag("Door4"))
        {
            atDoor = true;
            print("At door 4");

            if (Input.GetKeyDown(KeyCode.E))
            {
                print("Travel");
                self.transform.position = door3.position;
            }
        }

        if (other.gameObject.CompareTag("Door5"))
        {
            atDoor = true;
            print("At door 5");

            if (Input.GetKey(KeyCode.E))
            {
                print("Travel");
                self.transform.position = door6.position;
                lastDoor = 6;
            }
        }

        if (other.gameObject.CompareTag("Door6"))
        {
            atDoor = true;
            print("At door 6");

            if (Input.GetKeyDown(KeyCode.E))
            {
                print("Travel");
                self.transform.position = door5.position;
            }
        }

        if (other.gameObject.CompareTag("Door7"))
        {
            atDoor = true;
            print("At door 7");

            if (Input.GetKey(KeyCode.E))
            {
                print("Travel");
                self.transform.position = door8.position;
                lastDoor = 8;
            }
        }

        if (other.gameObject.CompareTag("Door8"))
        {
            atDoor = true;
            print("At door 8");

            if (Input.GetKeyDown(KeyCode.E))
            {
                print("Travel");
                self.transform.position = door7.position;
            }
        }

        if (other.gameObject.CompareTag("Door9"))
        {
            atDoor = true;
            print("At door 9");

            if (Input.GetKey(KeyCode.E))
            {
                print("Travel");
                self.transform.position = door10.position;
                lastDoor = 10;
            }
        }

        if (other.gameObject.CompareTag("Door10"))
        {
            atDoor = true;
            print("At door 9");

            if (Input.GetKeyDown(KeyCode.E))
            {
                print("Travel");
                self.transform.position = door9.position;
            }
        }

        if (other.gameObject.CompareTag("Dead"))
        {
            
            if (lastDoor == 2)
            {
                self.transform.position = door2.position;
            }

            else if (lastDoor == 4)
            {
                self.transform.position = door4.position;
            }

            else if (lastDoor == 6)
            {
                self.transform.position = door6.position;
            }

            else if (lastDoor == 8)
            {
                self.transform.position = door8.position;
            }

            else if (lastDoor == 10)
            {
                self.transform.position = door10.position;
            }
            
        }
    }

    public void Update()
    {
        if (ending.end == true)
        {
            camera1.enabled = false;
            camera2.enabled = true;
            Destroy(me);
        }
    }

}
