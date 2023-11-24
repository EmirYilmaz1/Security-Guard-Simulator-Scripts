using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    private Transform player;
    private Vector3 smootTime;
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position,new Vector3(player.position.x,transform.position.y,player.position.z),ref smootTime,3*Time.deltaTime);
    }
}
