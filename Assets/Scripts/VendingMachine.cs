using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    private bool isInFront;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            isInFront = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isInFront = false;
        }
    }
    void Start()
    {
        isInFront = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInFront)
        {
        }
    }
}
