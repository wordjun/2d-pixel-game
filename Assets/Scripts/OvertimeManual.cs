using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvertimeManual : MonoBehaviour
{
    [SerializeField] private bool isInFrontOfComputer;
    public Animator animator;
    void Start()
    {
        isInFrontOfComputer = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            isInFrontOfComputer = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isInFrontOfComputer = false;
        }
    }

    void Update()
    {
        if (isInFrontOfComputer)
        {
            animator.SetBool("Interact", true);
        }
        else
        {
            animator.SetBool("Interact", false);
        }
    }
}
