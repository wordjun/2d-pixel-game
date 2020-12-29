using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playFootsteps : MonoBehaviour
{
    public AudioSource[] audioSource = new AudioSource[4];
    private Animator animator;
    private bool isMoving;

    void Awake()
    {
        animator = this.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        int getRandomNum = getRandomNum = Random.Range(0, 4);//0~3사이 랜덤값 가져와서 효과음 play
        //float playerSpeed = animator.GetFloat("Speed");
        //Debug.Log("PLayer's speed: " + playerSpeed);
        if (Input.GetButtonDown("Horizontal")) 
        {
            Debug.Log("Moving");
            audioSource[getRandomNum].Play();
        }
    }
}
