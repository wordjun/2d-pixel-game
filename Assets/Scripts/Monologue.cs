using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monologue : MonoBehaviour
{
    public Animator animator;
    public float transitionTime;
    [SerializeField] private bool isInteracting;
    void Start()
    {
        isInteracting = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            isInteracting = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isInteracting = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isInteracting)
        {
            StartCoroutine(StartMonologue());
        }
    }

    IEnumerator StartMonologue()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
    }
}
