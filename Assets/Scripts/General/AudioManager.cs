using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityTypes;

public class AudioManager : Singleton<AudioManager>
{
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        ChangeVolume();
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ChangeVolume();
        if (scene.buildIndex is (int)UnityScenes.Hub or (int)UnityScenes.StartMenu)
        {
            var audio = Instance.GetComponent<AudioSource>();
            if (audio.isPlaying) return;
            audio.Play();
        }
        else
        { 
            Instance.GetComponent<AudioSource>().Stop();
        }
    }

    public void ChangeVolume()
    {
        if (!PlayerPrefs.HasKey("Volume")) return;
        var audioSources = GameObject.FindGameObjectsWithTag(UnityTags.Audio.ToString())
            .Select(a => a.GetComponent<AudioSource>());
        if (audioSources.Count() is 0) return;

        var enemy = GameObject.FindGameObjectWithTag(UnityTags.Enemy.ToString());
        var player = GameObject.FindGameObjectWithTag(UnityTags.Player.ToString());
        if (enemy)
        {
            enemy.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
        }

        if (player)
        {
            if (player.GetComponent<AudioSource>() != null)
            {
                player.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
            }
        }
        foreach (var audioSource in audioSources)
        {
            audioSource.volume = PlayerPrefs.GetFloat("Volume");
        }
    }
}
