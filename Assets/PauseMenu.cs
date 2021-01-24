using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject pauseMenuUI;
    void Start()
    {
        pauseMenuUI.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    /* 원래 스케일(Scale)이란 단어의 뜻이 규모, 등급 등을 나타내듯이, 
     * 유니티에서 Time.timeScale 프로퍼티는 시간이 어떤 속도로 흘러가는지를 의미합니다. 
     * Time.timeScale의 값이 1.0f라면 현재 유니티 씬의 시간이 실제 시간(real time)으로 
     * 흐른다는 것을 의미합니다. 반면에 0.5f라면 시간이 흐르는 속도가 절반이 된다는 의미입니다.
     * 만약 0.0f라면 모든 게임오브젝트가 정지합니다. 즉, 정지/포즈(pause) 상태를 구현할 수 있습니다.
     * 당연히 2.0f라면 2배의 속도로 움직이겠죠.
     * 다만 Time.timeScale 프로퍼티는 정적 프로퍼티(static property)이기 때문에 
     * 모든 씬의 게임오브젝트들이 공유하고 있습니다. 
     * 그러므로 Time.timeScale의 값을 변경하면 씬의 모든 게임오브젝트가 영향을 받습니다.
     */
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;//게임 흐름 재개
        isGamePaused = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;//게임 일시정지
        isGamePaused = true;
    }
    public void Quit()
    {
        Application.Quit();//게임종료
    }
}
