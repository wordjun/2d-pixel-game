using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterRoomUI : MonoBehaviour
{
    public Animator animator;
    public bool isInFrontOfRoom;
    void Start()
    {
        isInFrontOfRoom = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            isInFrontOfRoom = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isInFrontOfRoom = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isInFrontOfRoom)
        {
            animator.SetBool("Interact", true);
        }
        else if (!isInFrontOfRoom)
        {
            animator.SetBool("Interact", false);
        }
    }
}
