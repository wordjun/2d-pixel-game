using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public string introSceneName;
    public void PlayGame()
    {
        SceneManager.LoadScene(introSceneName);//게임 시작버튼 누르면 인트로화면으로 전환
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
