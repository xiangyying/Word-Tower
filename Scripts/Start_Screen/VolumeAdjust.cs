using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeAdjust : MonoBehaviour
{
    public Slider Volslider;
    public AudioSource music;

    public void Start()
    {
        Volslider.onValueChanged.AddListener(delegate { UpdateVolume(); });
    }

    void UpdateVolume()
    {
        music.volume = Volslider.value;
    }
}
