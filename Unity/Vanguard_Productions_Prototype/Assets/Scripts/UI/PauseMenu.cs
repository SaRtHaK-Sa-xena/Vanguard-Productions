using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    // Display Collections
    public GameObject collectionsDisplay;

    // Display the Memory
    public GameObject memoryHolder;

    public GameObject memoryBackgroundGraphic;
    public GameObject memoryPanel;

    // Current Memory gained from fragment interaction
    public Sprite currentMemorySprite;

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

    public void DisplayMemory()
    {
        // display memory
        //memoryHolder.SetActive(true);

        memoryBackgroundGraphic.SetActive(true);
        memoryPanel.SetActive(true);

        // set sprite of memory holder
        // to sprite from currentMemorySprite
        // gained from fragmentInteraction script
        //Debug.Log(currentMemorySprite.name);
        //memoryHolder.GetComponent<Image>().sprite = currentMemorySprite;

        // stop game
        Time.timeScale = 0f;
    }

    public void stopDisplayMemory()
    {
        // set memory false
        //memoryHolder.SetActive(false);

        memoryBackgroundGraphic.SetActive(false);
        memoryPanel.SetActive(false);

        // resume
        Resume();
    }

    public void unPauseGame()
    {
        Time.timeScale = 1.0f;
        GamePaused = false;
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

        // set collections to true
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
