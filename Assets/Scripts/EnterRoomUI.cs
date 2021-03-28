using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnterRoomUI : MonoBehaviour
{
    private bool isInFrontOfRoom;
    public Text text;
    void Start()
    {
        isInFrontOfRoom = false;
        text.canvasRenderer.SetAlpha(0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            isInFrontOfRoom = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isInFrontOfRoom = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isInFrontOfRoom)
        {
            text.canvasRenderer.SetAlpha(255);
        }
        else if (!isInFrontOfRoom)
        {
            text.canvasRenderer.SetAlpha(0);
        }
    }
}
