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
        //text의 알파값이 0이 아님과 동시에(현재 텍스트가 떠있는 상태) 
        //플레이어가 계단앞에 서있지 않은 경우
        if (text.canvasRenderer.GetAlpha() != 0 && !isAtLoader)
            text.canvasRenderer.SetAlpha(0);//텍스트 사라짐
        //반대로 text의 알파값이 0임과 동시에(현재 텍스트가 떠있지 않은 상태) 
        //플레이어가 계단앞에 서있는 경우
        if (text.canvasRenderer.GetAlpha() == 0 && isAtLoader)
            text.canvasRenderer.SetAlpha(255);//텍스트 뜸
    }
}
