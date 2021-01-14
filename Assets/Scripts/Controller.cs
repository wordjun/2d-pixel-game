using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera playerCam;
    public float flashlightFieldX;
    public float flashlightFieldY;
    public float sphereGizmosRadius;
    void OnDrawGizmos()
    {
        //Vector2 playerPos = rb.position;
        ////Vector3 p = playerCam.ScreenToWorldPoint(new Vector3(playerPos.x, playerPos.y, playerPos.z));
        ////Draw a yellow sphere at the transform's position
        Vector3 mousePos = playerCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(mousePos.x + flashlightFieldX, mousePos.y + flashlightFieldY), sphereGizmosRadius);

    }
    // Update is called once per frame
    void Update()
    {
        //화면좌표에서 world좌표로 변환
        //Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, viewCamera.transform.position.y, 0));
        //transform.LookAt(mousePos + Vector3.up * transform.position.x);
           
    }
}
