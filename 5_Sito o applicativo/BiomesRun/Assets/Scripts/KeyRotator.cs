using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRotator : MonoBehaviour
{
    public Vector3 rotation;

    // Update is called once per frame
    void Update()
    {
        // permette la rotazione di oggetti
        GetComponent<Transform>().Rotate(rotation);
    }
}
