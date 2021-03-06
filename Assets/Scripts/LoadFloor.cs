﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadFloor : MonoBehaviour
{
    //crossfade
    [SerializeField] private bool isAtLoader;
    private string FloorName;
    public string Upstairs;
    public string Downstairs;
    public Animator transition;
    //public GameObject crossfade;
    public float transitionTime = 1.0f;//crossfade 애니메이션 지속시간만큼 inspector에서 설정하면 된다.
    void Awake()
    {
        //crossfade.SetActive(false);
        FloorName = SceneManager.GetActiveScene().name;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            isAtLoader = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            isAtLoader = false;
    }
    void Update()
    {
        //다른 층으로 가는 문 앞에 서있고, 화살표 아래방향 키를 눌렀을 때 
        if (isAtLoader)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (Downstairs != "None")
                    //Debug.Log("Going downstairs.");
                    LoadDownstairs();
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if(Upstairs != "None")
                    LoadUpstairs();
            }
        }
    }
    public void LoadDownstairs()
    {
        StartCoroutine(LoadLevel(Downstairs));
    }
    public void LoadUpstairs()
    {
        StartCoroutine(LoadLevel(Upstairs));
    }
    //코루틴으로 crossfade animation time delay주기
    IEnumerator LoadLevel(string floor)
    {
        //play animation
        transition.SetTrigger("Start");
        //wait(pause this coroutine for x secs before going on
        yield return new WaitForSeconds(transitionTime);
        //load scene
        SceneManager.LoadScene(floor);
    }
}
