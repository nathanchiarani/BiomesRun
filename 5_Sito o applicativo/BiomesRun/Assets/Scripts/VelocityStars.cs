using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityStars : MonoBehaviour
{
    bool VelocityPlus = false;


    private void OnCollisionEnter(Collision collision)
    {
        // se collido con un oggetto con il tag stella rendo il player più veloce
        if (collision.gameObject.tag == "stella")
        {
            VelocityPlus = true;
        }
    }
}
