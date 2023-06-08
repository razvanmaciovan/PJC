using StateManager;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityTypes;

public class GameManager : Singleton<GameManager>
{
    private GameObject _mainCanvas;
    public UnityScenes LastScene { get; private set; } = UnityScenes.StartMenu;
    public PlayerDataScriptableObject PlayerData;

    public void Start()
    {
        //DataManager.Instance.LoadJson();
        StateController.ChangeState(GameState.Start);
        //_mainCanvas = GameObject.FindGameObjectWithTag(UnityTags.Canvas.ToString());
        OnLevelWasLoaded(1);
    }

    private void OnLevelWasLoaded(int level)
    {
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        switch (currentScene)
        {
            case (int)UnityScenes.Hub:
                UiManager.Instance.RefreshPlayerGear(false);
                break;
            case (int)UnityScenes.StartMenu:
                break;
            default:
                UiManager.Instance.RefreshPlayerGear();
                break;


        }
        //_mainCanvas = GameObject.FindGameObjectWithTag(UnityTags.Canvas.ToString());
        //if (LastScene != UnityScenes.Home ||
            //SceneManager.GetActiveScene().buildIndex == (int)UnityScenes.StartMenu) return;

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="scene">Specific UnityScene to change to</param>
    public void ChangeScene(UnityScenes scene)
    {
        LastScene = (UnityScenes)SceneManager.GetActiveScene().buildIndex;
        Instance.StartCoroutine(LoadScene(scene));
    }
    /// <summary>
    /// Changes to the previous scene
    /// </summary>
    public void ChangeScene()
    {
        var previousScene = LastScene;
        LastScene = (UnityScenes)SceneManager.GetActiveScene().buildIndex;
        Instance.StartCoroutine(LoadScene(previousScene));
    }

    private IEnumerator LoadScene(UnityScenes scene)
    {
        var sceneIndex = (int)scene;
        yield return null;
        if(StateController.CurrentGameState is GameState.Paused or GameState.Start)
        {
            StateController.ChangeState(GameState.Active);
        }
        //Begin to load the Scene you specify
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);
        //Don't let the Scene activate until you allow it to
        asyncOperation.allowSceneActivation = false;
        //When the load is still in progress, output the Text and progress bar
        while (!asyncOperation.isDone)
        {
            //Output the current progress
            //m_Text.text = "Loading progress: " + (asyncOperation.progress * 100) + "%";

            // Check if the load has finished
            if (asyncOperation.progress >= 0.9f)
            {
                //Change the Text to show the Scene is ready
                //m_Text.text = "Press the space bar to continue";
                //Wait to you press the space key to activate the Scene
                //if (Input.GetKeyDown(KeyCode.Space))
                    //Activate the Scene
                    asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    public void OnBossKilled(EnemyScriptableObject boss)
    {
        RewardManager.Instance.OnBossKilled(boss.EquipmentLevel + (int)boss.Difficulty);
        GameObject.FindGameObjectWithTag(UnityTags.BossCamera.ToString()).GetComponent<CameraBossDefeat>().OnBossKilled();
        var defeatedBosses = Resources.Load<EnemyListScriptableObject>("ScriptableObjects/DefeatedBosses");
        var selectedBosses = Resources.Load<EnemyScriptableObject>("ScriptableObjects/SelectedBoss");
        var totalBosses = Resources.Load<EnemyListScriptableObject>("ScriptableObjects/TotalBosses");
        if(defeatedBosses.EnemyList.Count(b => b.EquipmentLevel == selectedBosses.EquipmentLevel && b.Name == selectedBosses.Name) == 0)
        {
            defeatedBosses.EnemyList.Add(totalBosses.EnemyList.First(b => b.EquipmentLevel == selectedBosses.EquipmentLevel && b.Name == selectedBosses.Name));
            UnlockNextBoss();
        }
    }

    public void OnPlayerDeath()
    {
        var bossCamera = GameObject.FindGameObjectWithTag(UnityTags.BossCamera.ToString());
        bossCamera.GetComponentInChildren<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 3;
        bossCamera.GetComponent<CameraBossDefeat>().Hud.SetActive(false);
         
        StartCoroutine(FadeToBlack());
    }

    private IEnumerator FadeToBlack()
    {
        var fadeToBlackPrefab = Resources.Load<GameObject>("Prefabs/FadeToBlack");
        Instantiate(fadeToBlackPrefab,  GameObject.FindGameObjectWithTag(UnityTags.Canvas.ToString()).transform);
        yield return new WaitForSecondsRealtime(3);
        ChangeScene(UnityScenes.Hub);
    }

    public void UnlockNextBoss()
    {
        var totalBosses = Resources.Load<EnemyListScriptableObject>("ScriptableObjects/TotalBosses");
        var availableBosses = Resources.Load<EnemyListScriptableObject>("ScriptableObjects/AvailableBosses");

        var nextBoss = totalBosses.EnemyList.FirstOrDefault(b => !availableBosses.EnemyList.Contains(b));

        if (nextBoss is null)
        {
            Debug.LogError("RAN OUT OF BOSSES");
        }
        else
        {
            availableBosses.EnemyList.Add(nextBoss);
        }
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex == (int)UnityScenes.Hub)
        {
            DataManager.Instance.SaveIntoJson();
            ChangeScene(UnityScenes.StartMenu);
        }
    }

    //private void PauseGame()
    //{
    //    StateController.ChangeState(GameState.Paused);
    //    _iPauseMenu = Instantiate(_pauseMenu, _mainCanvas.transform);
    //}

    //public void DestroyPauseMenu()
    //{
    //    if (_iPauseMenu != null)
    //    {
    //        Destroy(_iPauseMenu.gameObject);
    //    }
    //}

}
