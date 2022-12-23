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
    public AudioSource gems;
    public AudioSource key;

    void Start()
    {
        bonusHitted = true;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "gemma")  // se collido con un oggetto con il tag gemma la distruggo e aggiungo un punto
        {
            if (bonusHitted)
            {
                gems.Play();
                Destroy(other.gameObject);
                bonusHitted = false;
                StartCoroutine(CollisionWithBonus());
            }
        }
        if (other.gameObject.tag == "keyCaveau")  // se collido con un oggetto con il tag keyCaveau lo distruggo e apro la porta associata
        {
            key.Play();
            Destroy(other.gameObject);
            GetComponent<OpenDoorsLevel2>().CaveauOpenDoor2 = true;
        }

        if (other.gameObject.tag == "finalKey") // se collido con un oggetto con il tag finalKey lo distruggo
        {
            key.Play();
            Destroy(other.gameObject);
        }
        if (punteggio == 9 && finalKey.gameObject == null) // se ho preso tutte le gemme e la final key apro la porta finale
        {
            GetComponent<OpenDoorsLevel2>().FinalOpenDoor2 = true;
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
