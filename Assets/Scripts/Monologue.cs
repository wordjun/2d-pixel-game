using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monologue : MonoBehaviour
{
    public Animator animator;
    public Text text;
    [SerializeField] private bool isInteracting;
    void Start()
    {
        isInteracting = false;
        text.canvasRenderer.SetAlpha(0);
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
            animator.SetTrigger("Start");
            text.canvasRenderer.SetAlpha(255);
        }
        else if (!isInteracting)
        {
            text.canvasRenderer.SetAlpha(0);
        }
    }

}
