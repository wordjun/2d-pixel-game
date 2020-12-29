using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isFacingRight = true;
    //private bool isCrouching = false;
    private float move = 0.0f;
    private Vector3 ZeroVelocity = Vector3.zero;
    [Range(0, .3f)] [SerializeField] private float MovementSmoothing = .05f;


    public Animator animator;
    public float runSpeed = 40f;
    float horizontalMove = 0f;

    public GameObject flashLight;
    bool isFlashlightOn = false;
    //bool crouch = false;

    [SerializeField] private AudioSource[] audioSource = new AudioSource[4];
    public AudioSource flashOnSound;
    //bool isMoving;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        flashLight.SetActive(false);
    }
    /*
     * UPDATE:
     * 스크립트가 enabled 상태일때, 매 프레임마다 호출됩니다. 
     * 일반적으로 가장 빈번하게 사용되는 함수이며, 
     * 물리 효과가 적용되지 않은 오브젝트의 움직임이나 
     * 단순한 타이머, 키 입력을 받을 때 사용됩니다.
     */
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        //F키로 스마트폰 후레쉬 on
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!isFlashlightOn)//현재 후레쉬 꺼진 상태면 키고
            {
                isFlashlightOn = true;
            }
            else//켜진상태면 끈다
            {
                isFlashlightOn = false;
            }
            flashLight.SetActive(isFlashlightOn);
            animator.SetBool("isFlashOn", isFlashlightOn);
            flashOnSound.Play();
        }
        //if (Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    crouch = true;

        //}
        //else if (Input.GetKeyUp(KeyCode.DownArrow))
        //{
        //    crouch = false;
        //}
    }
    //public void OnCrouching(bool isCrouching)
    //{
    //    animator.SetBool("isCrouching", isCrouching);
    //}
    /*
     * FIXEDUPDATE:
     * 프레임을 기반으로 호출되는 Update 와 달리 
     * Fixed Timestep에 설정된 값에 따라 일정한 간격으로 호출됩니다. 
     * 물리 효과가 적용된(Rigidbody) 오브젝트를 조정할 때 사용됩니다
     * (Update는 불규칙한 호출임으로 물리엔진 충돌검사 등이 제대로 안될 수 있음).
     */
    void FixedUpdate()//dedicated for physics
    {
        move = horizontalMove * Time.fixedDeltaTime;
        
        //move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(move * 10f, rb.velocity.y);
        //then smooth it out and apply it to the character
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref ZeroVelocity, MovementSmoothing);
       
        //왼쪽으로 향하고 있고, 오른쪽으로 움직이려하는 경우 flip시킨다
        if (move > 0 && !isFacingRight)
        {
            Flip();
        }
        //오른쪽을 향하고 있고 왼쪽으로 움직이려 하는 경우 역시 Flip시킴
        else if(move < 0 && isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        //toggle
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;//change x coord
        transform.localScale = theScale;
    }
}
