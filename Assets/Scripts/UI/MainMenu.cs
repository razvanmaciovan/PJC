using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityTypes;
public class MainMenu : MonoBehaviour
{
    public Slider VolumeSlider;

    private void Start()
    {
        VolumeSlider.onValueChanged.AddListener(delegate {OnVolumeChange();});
        if (PlayerPrefs.HasKey("Volume"))
        {
            VolumeSlider.value = PlayerPrefs.GetFloat("Volume");
        }
    }
    public void PlayGame()
   {
        DataManager.Instance.LoadJson();
        SceneManager.LoadScene((int)UnityScenes.Hub);
    }
    public void QuitGame()
    {
        DataManager.Instance.SaveIntoJson();
        Application.Quit();
    }

    public void OnVolumeChange()
    {
        PlayerPrefs.SetFloat("Volume",VolumeSlider.value);
        AudioManager.Instance.ChangeVolume();
    }
}
