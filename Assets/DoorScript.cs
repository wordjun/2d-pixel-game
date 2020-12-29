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

    private bool isInFrontofDoor;
    public AudioSource doorOpenSound;
    // Start is called before the first frame update
    void Start()
    {
        isInFrontofDoor = false;
    }
    void OnTriggerEnter(Collider2D other)
    {
        if (other.tag == "Player")
            isInFrontofDoor = true;
    }
    void OnTriggerExit(Collider2D other)
    {
        if (other.tag == "Player")
            isInFrontofDoor = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
