using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorLevel3 : MonoBehaviour
{
    public GameObject FinalDoor3;
    private Vector3 translateObj;
    public bool FinalOpenDoor3;

    public GameObject CaveauDoor3;
    public bool CaveauOpenDoor3;

    public GameObject SecretDoor3;
    public bool SecretOpenDoor3;
    // Start is called before the first frame update
    void Start()
    {
        // velocità di spostamento porte
        translateObj = new Vector3(0, -0.1f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // se la porta non è in quella posiozione la trasla tramite il translateobj facendola scivolare verso il basso
        if (FinalDoor3.GetComponent<Transform>().localPosition.y > -34f && FinalOpenDoor3)
        {
            FinalDoor3.GetComponent<Transform>().Translate(translateObj);
        }
        if (CaveauDoor3.GetComponent<Transform>().localPosition.y > -34f && CaveauOpenDoor3)
        {
            CaveauDoor3.GetComponent<Transform>().Translate(translateObj);
        }
        if (SecretDoor3.GetComponent<Transform>().localPosition.y > -34f && SecretOpenDoor3)
        {
            SecretDoor3.GetComponent<Transform>().Translate(translateObj);
        }
    }
}
