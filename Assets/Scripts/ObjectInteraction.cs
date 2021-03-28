using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectInteraction : MonoBehaviour
{
    [SerializeField] private bool isInFrontOfObject;
    public Text obsText;
    public Text intText;
    public string interactionText;
    public AudioSource audioSource;
    //public Animator animator;
    void Start()
    {
        obsText.canvasRenderer.SetAlpha(0);
        intText.canvasRenderer.SetAlpha(0);
        isInFrontOfObject = false;
        intText.text = interactionText;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isInFrontOfObject = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isInFrontOfObject = false;
        }
    }

    void Update()
    {
        TextFade();
        if (isInFrontOfObject && Input.GetKeyDown(KeyCode.E))
        {
            intText.canvasRenderer.SetAlpha(255);
            audioSource.Play();
        }
        else if (!isInFrontOfObject)
        {
            intText.canvasRenderer.SetAlpha(0);
        }
    }
    public void TextFade()
    {
        if (obsText.canvasRenderer.GetAlpha() != 0 && !isInFrontOfObject)
        {
            obsText.canvasRenderer.SetAlpha(0);//텍스트 사라짐
        }

        if (obsText.canvasRenderer.GetAlpha() == 0 && isInFrontOfObject)
        {
            obsText.canvasRenderer.SetAlpha(255);//텍스트 뜸
        }
    }
}
