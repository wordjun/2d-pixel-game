using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("F Floor");//4층에서부터 게임시작
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
