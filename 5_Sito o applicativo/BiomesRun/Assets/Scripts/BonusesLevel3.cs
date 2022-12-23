using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BonusesLevel3 : MonoBehaviour
{
    int punteggio = 0;
    bool bonusHitted;
    public GameObject keyDoor;
    public GameObject keyCaveau;
    public GameObject finalKey;
    public TextMeshProUGUI points;
    public AudioSource gems;
    public AudioSource key;

    private bool canFinalDoorOpen = false;

    void Start()
    {
        bonusHitted = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "gemma")
        {
            if (bonusHitted)
            {
                gems.Play();
                Destroy(other.gameObject);
                bonusHitted = false;
                StartCoroutine(CollisionWithBonus());
            }
        }

        if (other.gameObject.tag == "FirstKey")   // se collido con un oggetto con il tag FirstKey lo distruggo e apro la porta associata
        {
            key.Play();
            Destroy(other.gameObject);
            GetComponent<OpenDoorLevel3>().SecretOpenDoor3 = true;
        }

        if (other.gameObject.tag == "keyCaveau")  // se collido con un oggetto con il tag keyCaveau lo distruggo e apro la porta associata
        {
            key.Play();
            Destroy(other.gameObject);
            GetComponent<OpenDoorLevel3>().CaveauOpenDoor3 = true;
        }

        if (other.gameObject.tag == "fakeKey") // se collido con un oggetto con il tag fakeKey mi carica la schermata di perdita
        {
            key.Play();
            SceneManager.LoadScene(8);
        }

        if (other.gameObject.tag == "finalKey") // se collido con un oggetto con il tag finalKey lo distruggo
        {
            key.Play();
            Destroy(other.gameObject);
            canFinalDoorOpen = true;
        }
        if (punteggio == 11 && canFinalDoorOpen)  // se ho preso tutte le gemme e la final key apro la porta finale
        {
            GetComponent<OpenDoorLevel3>().FinalOpenDoor3 = true;
        }
    }

    IEnumerator CollisionWithBonus() // coroutine che aggiorna il punteggio
    {
        punteggio++;
        points.text = "Punteggio: " + punteggio.ToString();
        yield return new WaitForSeconds(0.5f);
        bonusHitted = true;
    }
}
