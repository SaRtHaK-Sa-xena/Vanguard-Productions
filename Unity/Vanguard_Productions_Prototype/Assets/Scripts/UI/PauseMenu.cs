using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;

    public GameObject pauseMenuUI;

    // all texts
    public GameObject Resume_txt;
    public GameObject Menu_txt;
    public GameObject Quit_txt;
    public GameObject Collections_txt;

    // Display Case
    public GameObject collectionsDisplay;

    // holds memoryFrags
    public List<GameObject> memoryFrags;

    public bool openedCollections = false;

    void Update() // CHeck if key is pressed to open/close Pause Menu
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                if(openedCollections)
                {
                    CloseCollections();
                }
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume () // Pause menu Closed
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    public void Pause () // Pause menu Opened
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void Menu (string SceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneName);
    }

    public void DisplayCollections()
    {
        // set all UI to false
        Resume_txt.SetActive(false);
        Menu_txt.SetActive(false);
        Quit_txt.SetActive(false);
        Collections_txt.SetActive(false);

        // display collections point
        collectionsDisplay.SetActive(true);

        openedCollections = true;
    }

    public void CloseCollections()
    {
        // set all UI to true
        Resume_txt.SetActive(true);
        Menu_txt.SetActive(true);
        Quit_txt.SetActive(true);
        Collections_txt.SetActive(true);

        //don't display collections point
        collectionsDisplay.SetActive(false);
    }

    public void QuitGame ()
    {
        Application.Quit();
    }
}
