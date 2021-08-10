using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }

    public string playerName; // name to save between scenes
    public int savedHighScore;

    public GameObject inputFieldObj;


    private void Awake()
    {
        //check to ensure gameobject doesn't already exist
       // InputField inputField = this.GetComponent<InputField>();

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        
    }

  
    public void SetPlayerName()
    {
        InputField inputField = inputFieldObj.GetComponent<InputField>();
        playerName = inputField.text;
    }

    public string GetPlayerName()
    {
        return playerName;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        // still need to add some function to save score data

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }


}
