using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityTypes;
public class MainMenu : MonoBehaviour
{
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
}
