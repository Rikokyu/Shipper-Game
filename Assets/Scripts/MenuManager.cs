using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;


public class MenuManager  : MonoBehaviour
{
        [SerializeField] float sceneLoadDelay = 2f;
    [SerializeField] GameObject helpScreen; // Tham chiếu đến HelpScreen Panel
    [SerializeField] GameObject infoScreen; // Tham chiếu đến InfoScreen Panel
    [SerializeField] GameObject settingScreen; // Tham chiếu đến SettingScreen Panel
    [SerializeField] GameObject mapScreen;

    public void ShowHelpScreen()
    {
        if (helpScreen != null)
        {
            helpScreen.SetActive(true);
        }
    }

    public void ShowInfoScreen()
    {
        if (infoScreen != null)
        {
            infoScreen.SetActive(true);
        }
    }
        public void ShowSettingScreen()
        {
            if (settingScreen != null)
            {
                settingScreen.SetActive(true);
            }
        }

    public void ShowMapScreen()
        {
            if (mapScreen != null)
            {
                mapScreen.SetActive(true);
            }
        }

    public void HideScreen()
    {
        // Đóng tất cả screens
        if (helpScreen != null)
        {
            helpScreen.SetActive(false);
        }
        if (infoScreen != null)
        {
            infoScreen.SetActive(false);
        }
        if (settingScreen != null)
        {
            settingScreen.SetActive(false);
        }
        if (mapScreen != null)
        {
            mapScreen.SetActive(false);
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

}
