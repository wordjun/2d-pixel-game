using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectInteraction : MonoBehaviour
{
    [SerializeField] private bool isInFrontOfObject;
    public Animator animator;
    void Start()
    {
        isInFrontOfObject = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isInFrontOfObject = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isInFrontOfObject = false;
        }
    }

    void Update()
    {
        if (isInFrontOfObject)
        {
            animator.SetBool("Interact", true);
        }
        else
        {
            animator.SetBool("Interact", false);
        }
    }
}
