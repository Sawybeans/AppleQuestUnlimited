using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingInit : MonoBehaviour
{

    public bool end;

    public void OnTriggerEnter2D(Collider2D col)
    {

        end = true;

    }

}
