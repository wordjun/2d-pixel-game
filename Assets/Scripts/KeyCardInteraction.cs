using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//ALL EVENTS MUST BE SET INACTIVE AFTER BEING TRIGGERED
public class KeyCardInteraction : MonoBehaviour
{
    public Text text;
    public bool hasPickedUpKey;
    public bool bSetInactive;
    void Awake()
    {
        text.canvasRenderer.SetAlpha(0);
        hasPickedUpKey = false;
        bSetInactive = false;
    }

    void Update()
    {
        PlayerItemInteraction player = FindObjectOfType<PlayerItemInteraction>();

        if (player.keyCards["KeyCard A"] && hasPickedUpKey)
        {
            //Debug.Log("picked up keycard A, player  is: " + player.name);
            StartCoroutine(pickUpMessage());
        }
        if (bSetInactive)
        {
            StartCoroutine(setInactive());
        }
    }
    IEnumerator pickUpMessage()
    {
        text.canvasRenderer.SetAlpha(255);
        yield return new WaitForSeconds(2.0f);
        text.canvasRenderer.SetAlpha(0);
        hasPickedUpKey = false;
    }

    IEnumerator setInactive()
    {
        yield return new WaitForSeconds(2.1f);
        gameObject.SetActive(false);
    }
}
