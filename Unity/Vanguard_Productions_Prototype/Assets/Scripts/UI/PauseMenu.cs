using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public bool GamePaused = false;

    public GameObject pauseMenuUI;

    // all texts
    public GameObject Resume_txt;
    public GameObject Menu_txt;
    public GameObject Quit_txt;
    public GameObject Collections_txt;
    public GameObject Options_txt;

    // Display Collections
    public GameObject collectionsDisplay;


    // Display the Memory=========
    public GameObject memoryHolder;
    // graphic and panel
    public GameObject memoryBackgroundGraphic;
    public GameObject memoryPanel;
    // Display the Memory=========


    // Reference to memory manager
    public GameObject objectivesManager;

    // Current Memory gained from fragment interaction
    public Sprite currentMemorySprite;

    // holds memoryFrags
    public List<GameObject> memoryFrags;

    // Collections Conditions =================
    // opened normally through menu
    public bool openedCollections = false;
    
    // opened through interaction
    public bool openedThroughInteraction = false;
    // Collections Conditions =================

    // Options KeyMapping
    public GameObject optionsDisplay;
    public bool optionsOpen;

    // Input manger
    public GameObject InputManager;

    void Update() // CHeck if key is pressed to open/close Pause Menu
    {
        // if the user presses C
        if(Input.GetKeyDown(KeyCode.C))
        {
            // if pressed when the collection was opened through interaction
            if(openedThroughInteraction)
            {
                // resume back to game
                Resume();
            }
        }

        // if escape pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // if the game is set to pause
            if (GamePaused)
            {
                // if the collections was opened
                if(openedCollections)
                {
                    // close collection
                    CloseCollections();
                }
                if(optionsOpen)
                {
                    CloseSettings();
                }
                // resume to game
                Resume();
            }

            // if game not paused
            else
            {
                // pause game
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

        Resume_txt.SetActive(true);
        Menu_txt.SetActive(true);
        Quit_txt.SetActive(true);
        Collections_txt.SetActive(true);
        Options_txt.SetActive(true);


        collectionsDisplay.SetActive(false);

        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void BackToCollections()
    {
        // turn on previous menu
        pauseMenuUI.SetActive(true);
        Menu_txt.SetActive(false);
        Quit_txt.SetActive(false);
        Collections_txt.SetActive(false);
        Resume_txt.SetActive(false);
        Options_txt.SetActive(false);

        // set memory display false
        memoryBackgroundGraphic.SetActive(false);
        memoryPanel.SetActive(false);

        collectionsDisplay.SetActive(true);

        openedThroughInteraction = true;

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

    // On Click in Collections Display
    // Whem clicking image
    public void setSpriteInManager(GameObject gO)
    {
        Debug.Log(this.gameObject.name);

        // if image exists
        if(gO.GetComponent<Image>().sprite.name != "memoryFragment")
        {
            // set manager sprite though objectives manager
            objectivesManager.GetComponent<Objectives>().setManagerSprite(gO.GetComponent<Image>().sprite);

            // Display Memory
            DisplayMemory();
        }
    }

    public void DisplayCollections()
    {
        // set all UI to false
        Resume_txt.SetActive(false);
        Menu_txt.SetActive(false);
        Quit_txt.SetActive(false);
        Collections_txt.SetActive(false);
        Options_txt.SetActive(false);

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
        Options_txt.SetActive(true);

        //don't display collections point
        collectionsDisplay.SetActive(false);
    }

    public void QuitGame ()
    {
        Application.Quit();
    }

    // Options===========
    // Key Mapping
    // Displays Debug info of new value selected
    // in control schemes

    // open settings menu
    public void OpenSettings()
    {
        // turn all menu items off
        Resume_txt.SetActive(false);
        Menu_txt.SetActive(false);
        Quit_txt.SetActive(false);
        Collections_txt.SetActive(false);
        Options_txt.SetActive(false);
        
        // turn on options menu
        optionsDisplay.SetActive(true);

        // set condition for options to true
        optionsOpen = true;
    }


    public void CloseSettings()
    {
        // turn all menu items off
        Resume_txt.SetActive(true);
        Menu_txt.SetActive(true);
        Quit_txt.SetActive(true);
        Collections_txt.SetActive(true);
        Options_txt.SetActive(true);

        // turn on options menu
        optionsDisplay.SetActive(false);

        // set condition for options to true
        optionsOpen = false;
    }

    // Change values in keymapping settings
    public void ChangeKeyMapping(TMP_Dropdown a_dropDown)
    {
        // send data of value and run new key mapping function
        InputManager.GetComponent<ControlManager>().ChangeKeyCode(a_dropDown.options[a_dropDown.value].text);

        // Debug purposes
        Debug.Log(a_dropDown.options[a_dropDown.value].text);
    }

}
