using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string SceneName;
    private bool isAtTrigger;//이동할 장소의 문 앞에 서있는지에 대한 유무확인용
    public Animator transition;
    public float transitionTime = 1.0f;//장면 load(transition)하는 시간
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            isAtTrigger = true;

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            isAtTrigger = false;
    }
    void Start()
    {
        isAtTrigger = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (isAtTrigger)//화장실 앞에 서있을때
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))//↓키 누르면 해당 층 화장실로 이동
            {
                StartCoroutine(EnterRoom());
            }
        }
    }

    IEnumerator EnterRoom()
    {
        
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(SceneName);
    }
}
