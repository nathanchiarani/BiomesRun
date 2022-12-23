using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BonusesLevel1 : MonoBehaviour
{
    bool bonusHitted;
    int punteggio = 0;
    public TextMeshProUGUI points;
    public AudioSource gems;
    // Start is called before the first frame update
    void Start()
    {
        bonusHitted = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "gemma") // se collido con un oggetto con il tag gemma la distruggo e aggiungo un punto
        {
            if (bonusHitted)
            {
                gems.Play();
                Destroy(other.gameObject);
                bonusHitted = false;
                StartCoroutine(CollisionWithBonus());
            }
        }
        if (punteggio == 6) // se il punteggio è 6 apro la porta
        {
            GetComponent<OpenDoorLevel1>().OpenDoor1 = true;
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
