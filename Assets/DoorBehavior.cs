using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorBehavior : MonoBehaviour
{

    public AudioSource doorSound;
    public Rigidbody2D protagSpeed;

    public AudioSource scream1;
    public AudioSource scream2;
    public AudioSource scream3;
    public AudioSource scream4;
    public AudioSource scream5;
    public int screamRand;

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
                doorSound.Play();
                protagSpeed.velocity = Vector3.zero;
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
                doorSound.Play();
                protagSpeed.velocity = Vector3.zero;
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
                doorSound.Play();
                protagSpeed.velocity = Vector3.zero;
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
                doorSound.Play();
                protagSpeed.velocity = Vector3.zero;
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
                doorSound.Play();
                protagSpeed.velocity = Vector3.zero;
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
                doorSound.Play();
                protagSpeed.velocity = Vector3.zero;
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
                doorSound.Play();
                protagSpeed.velocity = Vector3.zero;
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
                doorSound.Play();
                protagSpeed.velocity = Vector3.zero;
            }
        }

        if (other.gameObject.CompareTag("Door9"))
        {
            atDoor = true;
            print("At door 9");

            if (Input.GetKey(KeyCode.E))
            {
                print("Travel");
                doorSound.Play();
                protagSpeed.velocity = Vector3.zero;

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
                doorSound.Play();
                protagSpeed.velocity = Vector3.zero;
            }
        }

        if (other.gameObject.CompareTag("Dead"))
        {

            screamRand = Random.Range(1, 5);

            if (screamRand == 1)
            {
                scream1.Play();
            }

            if (screamRand == 2)
            {
                scream2.Play();
            }

            if (screamRand == 3)
            {
                scream3.Play();
            }

            if (screamRand == 4)
            {
                scream4.Play();
            }

            if (screamRand == 5)
            {
                scream5.Play();
            }

            //Warp to last used door
            if (lastDoor == 2)
            {
                protagSpeed.velocity = Vector3.zero;
                self.transform.position = door2.position;
            }

            else if (lastDoor == 4)
            {
                protagSpeed.velocity = Vector3.zero;
                self.transform.position = door4.position;
            }

            else if (lastDoor == 6)
            {
                protagSpeed.velocity = Vector3.zero;
                self.transform.position = door6.position;
            }

            else if (lastDoor == 8)
            {
                protagSpeed.velocity = Vector3.zero;
                self.transform.position = door8.position;
            }

            else if (lastDoor == 10)
            {
                protagSpeed.velocity = Vector3.zero;
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
