using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Slider volumeBar;
    public float soundVolume;
    public void VolumeControl()
    {
        soundVolume = volumeBar.value;
    }
}
