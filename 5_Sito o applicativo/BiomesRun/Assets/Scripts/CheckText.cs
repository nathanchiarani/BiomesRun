using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckText : MonoBehaviour
{
    public TMP_InputField text;
    public GameObject button;
    void Update()
    {
        if(text.text.Length > 0) // verifico se nel textbox del nome è stato inserito qualcosa, se vuoto il textbox è enabled
        {
            button.GetComponent<Button>().enabled = true;
        }
        else
        {
            button.GetComponent<Button>().enabled = false;
        }
    }
}
