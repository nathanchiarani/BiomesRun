using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        // se non ci sono settate le impostazioi le setta, altrimenti tienme quelle gia impostate
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 0.2f);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume() // modifica il volume del gioco
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load() //carica le impostazioni dello slider
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save() // salva le impostazioni delli slider
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
