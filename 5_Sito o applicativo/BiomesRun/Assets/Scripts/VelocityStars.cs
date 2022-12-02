using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityStars : MonoBehaviour
{
    bool VelocityPlus = false;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "stella")
        {
            VelocityPlus = true;
        }
    }

    IEnumerator CollisionWithStar()
    {
        
        yield return new WaitForSeconds(3f);
        VelocityPlus = false;
    }
}
