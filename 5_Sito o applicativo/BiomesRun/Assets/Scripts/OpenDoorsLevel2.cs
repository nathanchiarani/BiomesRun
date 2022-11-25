using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorsLevel2 : MonoBehaviour
{
    public GameObject FinalDoor2;
    private Vector3 translateObj;
    public bool FinalOpenDoor2;

    public GameObject CaveauDoor2;
    public bool CaveauOpenDoor2;
    // Start is called before the first frame update
    void Start()
    {
        translateObj = new Vector3(0, -0.1f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (FinalDoor2.GetComponent<Transform>().localPosition.y > -34f && FinalOpenDoor2)
        {
            FinalDoor2.GetComponent<Transform>().Translate(translateObj);
        }
        if (CaveauDoor2.GetComponent<Transform>().localPosition.y > -34f && CaveauOpenDoor2)
        {
            CaveauDoor2.GetComponent<Transform>().Translate(translateObj);
        }
    }
}
