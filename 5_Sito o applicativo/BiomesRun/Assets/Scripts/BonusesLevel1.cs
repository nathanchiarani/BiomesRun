using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BonusesLevel1 : MonoBehaviour
{
    bool bonusHitted;
    int punteggio = 0;
    public TextMeshProUGUI points;
    // Start is called before the first frame update
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
        if (punteggio == 6)
        {
            GetComponent<OpenDoorLevel1>().OpenDoor1 = true;
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
