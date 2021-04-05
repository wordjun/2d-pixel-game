using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public GameObject[] events;

    //static variables to check that events have finished once and for all
    public static bool isKeyCardEventDone;
    public static bool isMonologueEventDone;
    /*
     * static변수에 대해: static으로 선언된 변수는
     * 객체를 선언만 하여도 메모리가 할당이 되며, 
     * 일반 변수들은 객체생성 시 메모리가 초기화되는 반면
     * static변수들은 해당 객체를 계속 반복적으로 생성해도
     * 메모리가 유지된다는 특징을 갖는다.
     * 결론: static필드는 프로그램 실행 후 해당 클래스가
     * 처음으로 사용될때 한번 초기화되어 계속 동일한 메모리를
     * 사용하게 된다.
     * 즉, 이 변수들은 어떠한 이벤트가 종료되고 나면 그 종료된 event의
     * 상태를 다른 scene을 로딩하더라도 유지할 수 있어야 한다.
     * 다른 scene로딩하게 되면 DDOL에 없는 객체들이 다시 생성되기 때문
     */

    void Start()
    {
        isKeyCardEventDone = false;
        isMonologueEventDone = false;
    }

    void Update()
    {
        KeyCardInteraction keyCard = FindObjectOfType<KeyCardInteraction>();
        FourthFloorScreamMonologue mono = FindObjectOfType<FourthFloorScreamMonologue>();
        events = GameObject.FindGameObjectsWithTag("Event");

        for(int i = 0; i < events.Length; i++)
        {
            Debug.Log("Found an event: " + events[i].name + ", with index "+i);
            if (events[i].name == "KeyCardInteraction" && keyCard.hasPickedUpKey)
            {
                keyCard.bSetInactive = true;
                isKeyCardEventDone = true;
            }

            if(events[i].name == "Monologues" && mono.isMonologueDone)
            {
                isMonologueEventDone = true;
            }
        }
    }
    
}
