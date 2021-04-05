using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ALL EVENTS MUST BE SET INACTIVE AFTER BEING TRIGGERED
public class FourthFloorScreamMonologue : MonoBehaviour
{
    public Text guideText;
    public Animator animator;
    public AudioSource scream;
    public bool isMonologueDone;

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
        PlayerItemInteraction player = FindObjectOfType<PlayerItemInteraction>();
        if(player.keyCards["KeyCard A"] == true && isInteracting)
        {
            StartCoroutine(startMonologue());
        }
        if ((isMonologueDone && guideText.canvasRenderer.GetAlpha() == 0) || EventsManager.isMonologueEventDone)
        {
            StartCoroutine(setInactive());
        }
        
    }

    IEnumerator startMonologue()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(4.1f);
        guideText.canvasRenderer.SetAlpha(255);
        yield return new WaitForSeconds(4.1f);
        isMonologueDone = true;
        guideText.canvasRenderer.SetAlpha(0);
    }

    IEnumerator setInactive()
    {
        yield return new WaitForSeconds(2.0f);
        gameObject.SetActive(false);
    }
}