using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    /*
     *   1.    Awake
        인스펙터창에서 스크립트요소를 비활성화 해도 실행된다. 스크립트와 초기화 사이의 모든 레퍼런스 설정에 이용
         2.   Start
        Awake다음으로 첫 업데이트 직전에 호출되지만 스크립트 요소가 활성화 상태여야 합니다.
 
        예))
        Awake: 적들에게 총의 총알을 초기화한다.(Set)
        Start:적들에게 총을 쏳을 능력을 부여할때
     */

    [SerializeField] private bool isInFrontofDoor;
    [SerializeField] private bool isDoorOpen;
    public AudioSource doorOpenSound;
    public AudioSource doorCloseSound;
    public Animator animator;
    [SerializeField] private BoxCollider2D passThrough;
    // Start is called before the first frame update
    void Start()
    {
        isInFrontofDoor = false;
        isDoorOpen = false;
        passThrough.isTrigger = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            isInFrontofDoor = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            isInFrontofDoor = false;
    }
    // Update is called once per frame
    void Update()
    {
        //플레이어가 문앞에 서있는 경우
        if (isInFrontofDoor)
        {
            animator.SetBool("Interact", true);
            //문이 닫긴 상태이며 E키를 눌렀을때
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!isDoorOpen)
                {
                    isDoorOpen = true;
                    doorOpenSound.Play();
                }
                else
                {
                    isDoorOpen = false;
                    doorCloseSound.Play();
                }
                animator.SetBool("isOpen", isDoorOpen);
                passThrough.isTrigger = isDoorOpen;//true가 되면 trigger가 켜지면서 통과가능
            }
        }
        else
        {
            animator.SetBool("Interact", false);
        }
    }
}
