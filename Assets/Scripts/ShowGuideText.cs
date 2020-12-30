using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowGuideText : MonoBehaviour
{
    //text to guide
    [SerializeField] private bool isAtLoader;
    public Text text;
    bool fading;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            isAtLoader = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            isAtLoader = false;
    }
    void Start()
    {
        text.canvasRenderer.SetAlpha(0);
    }
    // Update is called once per frame
    void Update()
    {
        //다른 층으로 가는 문 앞에 서있고, 화살표 아랫방향 키를 눌렀을 때 
        TextFade();
    }
    public void TextFade()
    {
        //Debug.Log(text.canvasRenderer.GetAlpha());
        if (text.canvasRenderer.GetAlpha() != 0 && !isAtLoader)
            text.canvasRenderer.SetAlpha(0);
        if (text.canvasRenderer.GetAlpha() == 0 && isAtLoader)
            text.canvasRenderer.SetAlpha(255);
    }
}
