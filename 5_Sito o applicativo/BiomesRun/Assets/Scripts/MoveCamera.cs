using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;
    // Update is called once per frame
    void Update()
    {
        //prende la posizione della main camera
        transform.position = cameraPosition.position;
    }
}
