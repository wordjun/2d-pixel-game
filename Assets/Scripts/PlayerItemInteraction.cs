using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemInteraction : MonoBehaviour
{
    public Dictionary<string, bool> keyCards;
    void Start()
    {
        keyCards = new Dictionary<string, bool>();
        keyCards.Add("KeyCard A", false);
        keyCards.Add("KeyCard B", false);
        keyCards.Add("KeyCard C", false);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //충돌한 오브젝트 확인
        IItem item = other.GetComponent<IItem>();

        if(item != null)
        {
            item.onPIckUp();
        }
    }
}
