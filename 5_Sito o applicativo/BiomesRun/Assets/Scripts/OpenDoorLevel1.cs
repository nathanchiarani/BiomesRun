using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorLevel1 : MonoBehaviour
{
    public GameObject Door1;
    private Vector3 translateObj;
    public bool OpenDoor1;
    // Start is called before the first frame update
    void Start()
    {
        translateObj = new Vector3(0, -0.1f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Door1.GetComponent<Transform>().localPosition.y > -34f && OpenDoor1)
        {
            Door1.GetComponent<Transform>().Translate(translateObj);
        }
    }
}
