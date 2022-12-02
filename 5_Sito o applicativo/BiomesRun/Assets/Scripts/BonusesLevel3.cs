using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BonusesLevel3 : MonoBehaviour
{
    int punteggio = 0;
    bool bonusHitted;
    public GameObject keyDoor;
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

        if (other.gameObject.tag == "FirstKey")
        {
            Destroy(other.gameObject);
            GetComponent<OpenDoorLevel3>().SecretOpenDoor3 = true;
        }

        if (other.gameObject.tag == "keyCaveau")
        {
            Destroy(other.gameObject);
            GetComponent<OpenDoorLevel3>().CaveauOpenDoor3 = true;
        }

        if (other.gameObject.tag == "fakeKey")
        {
            //SceneManager.LoadScene(<perditaPerChiave>);
        }

        if (other.gameObject.tag == "finalKey")
        {
            Destroy(other.gameObject);
        }
        if (punteggio == 11 && finalKey.gameObject == null)
        {
            GetComponent<OpenDoorLevel3>().FinalOpenDoor3 = true;
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
