using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSound : MonoBehaviour
{
    public AudioSource scream;
    private bool isPlayerAtPos;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            isPlayerAtPos = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            isPlayerAtPos = false;
    }
    
    void Update()
    {
        PlayerItemInteraction player = FindObjectOfType<PlayerItemInteraction>();
        
        if (player.keyCards["KeyCard A"] == true && isPlayerAtPos)
        {
            scream.Play();
            StartCoroutine(setInactive());
        }
    }

    IEnumerator setInactive()
    {
        yield return new WaitForSeconds(3.0f);//3 seconds enough for scream to play
        gameObject.SetActive(false);
    }
}
