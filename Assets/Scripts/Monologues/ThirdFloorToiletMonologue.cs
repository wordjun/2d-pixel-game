using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ALL EVENTS MUST BE SET INACTIVE AFTER BEING TRIGGERED
public class ThirdFloorToiletMonologue : MonoBehaviour
{
    public static bool isBodyGone;
    public static bool hasCalled911;
    private bool isMonologueDone;
    private bool isDoorOpen;
    public Animator animator;
    public Text text;
    [SerializeField] private bool isInteracting;
    void Start()
    {
        isInteracting = false;
        text.canvasRenderer.SetAlpha(0);
        isDoorOpen = false;
        isBodyGone = false;
        hasCalled911 = false;
        isMonologueDone = false;
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
        if (isInteracting)//if player is inside the colliderbox
        {
            animator.SetTrigger("Monologue1");//set the animator trigger, start monologue animation
            text.canvasRenderer.SetAlpha(255);//trigger "OPEN" UI

            if (!isDoorOpen && Input.GetKeyDown(KeyCode.E))//if the door is closed and the player entered "E" key to open it, start the next sequence
            {
                isDoorOpen = true;
                text.gameObject.SetActive(false);

                //Debug.Log("Entered E, door now opening.");
                //dead woman inside toilet
                StartCoroutine(startMonologue());
            }
        }
        else if (!isInteracting)//if player's outside the colliderbox
        {
            text.canvasRenderer.SetAlpha(0);//make the "OPEN" UI disappear
        }


        if (isMonologueDone)
        {
            text.gameObject.SetActive(false);
        }
    }
    IEnumerator startMonologue()
    {
        animator.SetTrigger("Monologue2");
        yield return new WaitForSeconds(15);
        isMonologueDone = true;
        gameObject.SetActive(false);
    }
}
