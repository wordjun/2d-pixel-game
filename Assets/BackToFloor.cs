using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToFloor : MonoBehaviour
{
    private bool isAtToilet;//화장실 문 앞에 서있는지에 대한 유무확인용
    public Animator transition;
    public float transitionTime = 1.0f;//장면 load(transition)하는시간

    void OnTriggerEnter2D(Collider2D other)//화장실 앞에 서있는경우
    {
        if (other.tag == "Player")
            isAtToilet = true;

    }
    void OnTriggerExit2D(Collider2D other)//화장실 앞을 떠나는경우
    {
        if (other.tag == "Player")
            isAtToilet = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (isAtToilet)//화장실 앞에 서있을때
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))//↓키 누르면 해당 층 화장실로 이동
            {
                StartCoroutine(GoBack());
            }
        }
    }

    IEnumerator GoBack()
    {
        //프로젝트 scene 구성에서 scene build index - 3 하면 
        //해당 층 남자화장실에서 해당층으로 다시 이동할 수 있도록 설정
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);//설정한 transition time만큼 대기
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
}
