using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PointClick : MonoBehaviour
{
    private string m_sceneToLoad;

    public void SceneLoader(string SceneIndex)
    {
        //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        //m_sceneToLoad = SceneName;
        //AsyncOperation ao = SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);
        //ao.completed += LoadComplete;
        SceneManager.LoadScene(SceneIndex);
    }

    public void SceneLoaderAdditive(string SceneName)
    {
        m_sceneToLoad = SceneName;
        AsyncOperation ao = SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);
        ao.completed += LoadComplete;    
    }

    private void LoadComplete(AsyncOperation ao)
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(m_sceneToLoad));
        print(SceneManager.GetActiveScene().name);
        ao.completed -= LoadComplete;
    }

    public void OnMouseUp()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
