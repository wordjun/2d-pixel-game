using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FourthFloorScreamMonologue : MonoBehaviour
{
    public Text guideText;
    public Animator animator;
    private bool isMonologueDone;
    [SerializeField] private bool isInteracting;
    void Start()
    {
        isInteracting = false;
        isMonologueDone = false;
        guideText.canvasRenderer.SetAlpha(0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
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
        if (!isMonologueDone)
        {
            if (isInteracting)//if player is inside the colliderbox and hasn't started the monologue yet
            {
                animator.SetTrigger("Start");//set the animator trigger, start monologue animation
                StartCoroutine(MonologueDone());
            }
        }
        else if (isMonologueDone)
        {
            //animator.SetTrigger("End");//set the animator trigger, end the animation
            guideText.canvasRenderer.SetAlpha(255);//pop up guidetext
        }
    }
    IEnumerator MonologueDone()
    {
        yield return new WaitForSeconds(2.0f);
        isMonologueDone = true;
    }
}