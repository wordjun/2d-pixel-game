using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvertimeManual : MonoBehaviour
{
    [SerializeField] private bool isInFrontOfComputer;
    public Animator animator;
    public GameObject manual;
    private bool isManualActive;
    void Start()
    {
        isInFrontOfComputer = false;
        isManualActive = false;
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
            if (Input.GetKeyDown(KeyCode.E) && !isManualActive)
            {
                manual.SetActive(true);
                isManualActive = true;
                Time.timeScale = 0;//pause temporarily
            }
            else if (isManualActive)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    manual.SetActive(false);
                    isManualActive = false;
                    Time.timeScale = 1;
                }
            }
        }
        else
        {
            animator.SetBool("Interact", false);
        }
    }
}
