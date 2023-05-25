using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityTypes;
public class MainMenu : MonoBehaviour
{
   public void PlayGame()
    {
        SceneManager.LoadScene((int)UnityScenes.Hub);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
