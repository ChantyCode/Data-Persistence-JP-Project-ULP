using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
    using UnityEditor;
#endif
public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance;
    public enum Scenes
    {
        main,
        menu
    }
    void Awake()
    {
        Instance = this;
    }
    public void LoadMainScene()
    {
        SceneManager.LoadScene(ScenesManager.Scenes.main.ToString());
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
}
