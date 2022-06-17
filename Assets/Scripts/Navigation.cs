using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    void Start()
    {

    }
    
    public void Update()
    {
        PreviousScene();
    }

    public static void PreviousScene()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                Application.Quit();
            }
            else if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                SceneManager.LoadScene(0);
            }
            else if (SceneManager.GetActiveScene().buildIndex > 1)
            {
                SceneManager.LoadScene(1);
            }
        }
    }

    public void BackToObjectMenu()
    {
        SceneManager.LoadScene(1);
    }
}
