using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Save_Settings : MonoBehaviour
{
    [SerializeField] private Slider Volslider = null;

    private void Start()
    {

    }

    public void SaveAll()
    {
        SaveVolume();
        SceneManager.LoadScene("Start_Screen");
    }

    public void SaveVolume()
    {
        // Save the volume
        float vol_val = Volslider.value;
        PlayerPrefs.SetFloat("Volume", vol_val);
        LoadValues();
    }
    void LoadValues()
    {
        // Load the volume
        float vol_val = PlayerPrefs.GetFloat("Volume");
        Volslider.value = vol_val;
        AudioListener.volume = vol_val;
    }
}
