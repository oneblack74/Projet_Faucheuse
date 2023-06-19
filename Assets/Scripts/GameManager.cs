//Script d'Axel

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance {private set; get; }
    public PlayerInput inputs;

    /*private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);

        //inputs = GetComponent<PlayerInput>();
    }*/

    public static GameManager GetInstance()
    {
        return instance;
    }

    public PlayerInput GetInputs()
    {
        return inputs;
    }

    public void ChangeScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public IEnumerator LoadGameSceneAsync()
    {
        // Charge la scène "GameManagerScene" en premier
        AsyncOperation asyncLoadGameManager = SceneManager.LoadSceneAsync("GameManagerScene");

        while (!asyncLoadGameManager.isDone)
        {
            yield return null;
        }

        // Une fois la scène "GameManagerScene" chargée, charge la scène principale
        AsyncOperation asyncLoadMainScene = SceneManager.LoadSceneAsync("MainScene");

        while (!asyncLoadMainScene.isDone)
        {
            yield return null;
        }

        // Ici, vous pouvez placer le code pour charger les données et placer le joueur sur la statue
        SaveData saveData = GameObject.FindObjectOfType<SaveData>();
        if (saveData != null)
        {
            saveData.Charger();
            //saveData.PlacerJoueurSurStatue();
        }
    }


    /*
    public IEnumerator LoadGameSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainScene");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        SaveData saveData = GameObject.Find("SaveManager").GetComponent<SaveData>();
        saveData.Charger(); // Charger les données depuis la sauvegarde
        //saveData.PlacerJoueurSurStatue(); // Placer le joueur aux coordonnées de la statue
    }*/

    public void OnPlayButtonClicked()
    {
        StartCoroutine(LoadGameSceneAsync());
    }

    public void Quit()
    {
        Application.Quit();
    }
}
