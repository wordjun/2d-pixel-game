using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OvertimeManual : MonoBehaviour
{
    [SerializeField] private bool isInFrontOfComputer;
    public Animator animator;
    public GameObject manual;
    private bool isManualActive;
    public AudioSource interactSound;
    public AudioSource exitSound;
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
                interactSound.Play();
                manual.SetActive(true);
                isManualActive = true;
                Time.timeScale = 0;//pause temporarily
            }
            else if (isManualActive)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    exitSound.Play();
                    manual.SetActive(false);
                    isManualActive = false;
                    Time.timeScale = 1;//unpause
                }
            }
        }
        else
        {
            animator.SetBool("Interact", false);
        }
    }
}
