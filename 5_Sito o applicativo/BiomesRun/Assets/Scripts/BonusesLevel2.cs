using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BonusesLevel2 : MonoBehaviour
{
    // Start is called before the first frame update
    int punteggio = 0;
    bool bonusHitted;
    public GameObject keyCaveau;
    public GameObject finalKey;
    public TextMeshProUGUI points;

    void Start()
    {
        bonusHitted = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "gemma")
        {
            if (bonusHitted)
            {
                Destroy(other.gameObject);
                bonusHitted = false;
                StartCoroutine(CollisionWithBonus());
            }
        }
        if (other.gameObject.tag == "keyCaveau")
        {
            Destroy(other.gameObject);
            GetComponent<OpenDoorsLevel2>().CaveauOpenDoor2 = true;
        }

        if (other.gameObject.tag == "finalKey")
        {
            Destroy(other.gameObject);
        }
        if (punteggio == 9 && finalKey.gameObject == null)
        {
            GetComponent<OpenDoorsLevel2>().FinalOpenDoor2 = true;
        }
    }

    IEnumerator CollisionWithBonus()
    {
        punteggio++;
        points.text = "Punteggio: " + punteggio.ToString();
        yield return new WaitForSeconds(0.5f);
        bonusHitted = true;
    }
}
