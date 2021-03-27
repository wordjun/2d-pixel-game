using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCard : MonoBehaviour, IItem
{
    
    public void onPIckUp()
    {
        PlayerItemInteraction player = FindObjectOfType<PlayerItemInteraction>();
        KeyCardInteraction keyCard = FindObjectOfType<KeyCardInteraction>();

        player.keyCards["KeyCard A"]= true;
        keyCard.hasPickedUpKey = true;
        gameObject.SetActive(false);//after picking up, keycard should no more be visible
    }
}
