using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDOL : MonoBehaviour
{
    public DDOL[] obj;
    void Awake()
    {

        obj = FindObjectsOfType<DDOL>();
        //Debug.Log("outside for loop obj length: " + obj.Length);
        for (int i = 0; i < obj.Length; i++)
        {
            //Debug.Log("inside for looop obj length: " + obj.Length);
            if (obj.Length == 1)
            {
                //Debug.Log("Not destroying: " + i);
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                //Debug.Log("Destroying: " + i);
                Destroy(gameObject);
            }
        }
    }

}
