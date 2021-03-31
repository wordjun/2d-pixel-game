using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public GameObject[] events;

    void Update()
    {
        KeyCardInteraction keyCard = FindObjectOfType<KeyCardInteraction>();
        events = GameObject.FindGameObjectsWithTag("Event");
        for(int i = 0; i < events.Length; i++)
        {
            Debug.Log("Found an event: " + events[i].name + ", with index "+i);
            if (events[i].name == "KeyCardInteraction" && keyCard.hasPickedUpKey)
            {
                keyCard.bSetInactive = true;
            }

        }
    }
    
}
