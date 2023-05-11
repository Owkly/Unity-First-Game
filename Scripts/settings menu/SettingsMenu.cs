using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Dropdown resolutionDropDown;

    Resolution[] resolutions;

    public Slider MusicSlider;
    public Slider soundSlider;

    public void Start()
    {
        //Permet de récupérer le niveau du son actuel
        audioMixer.GetFloat("Music", out float musicValueForSlider);
        MusicSlider.value = musicValueForSlider;

        audioMixer.GetFloat("Sound", out float soundValueForSlider);
        soundSlider.value = soundValueForSlider;

        resolutions = Screen.resolutions.Select(Resolution => new Resolution { width = Resolution.width, height = Resolution.height }).Distinct().ToArray();

        //permet de supprimer les options par défaut
        resolutionDropDown.ClearOptions();

        //crée notre nouvelle liste et l'affecter
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            //On crée donc de nouvelle string à chaque tour de boucle et on l'ajoute
            //à chaque fois dans la list options
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;

        //permet de raffraîchir l'élément selectionné
        resolutionDropDown.RefreshShownValue();

    }

    public void SetVolume(float Volume)
    {
        audioMixer.SetFloat("Music", Volume);
    }

    public void SetSoundVolume(float Volume)
    {
        audioMixer.SetFloat("Sound", Volume);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;  
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void ClearSavedData()
    {
        PlayerPrefs.DeleteAll();    
    }
}
