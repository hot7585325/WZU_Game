using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool IsOpenMenu;
    public GameObject Menu;


    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenMenu()
    {
        IsOpenMenu = !IsOpenMenu;

        if (IsOpenMenu)
        {
            Menu.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            Menu.SetActive(false);
            Time.timeScale = 1;
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenMenu();
        }
    }


    public void LoadScenes(int index)
    {
        SceneManager.LoadScene(index);
        Time.timeScale = 1;
    }
}
