using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float xOffset, yOffset, zOffset;

    public void Start()
    {
        player = GameObject.Find("Ball");
    }

    void Update()
    {
        //la caméra suit la balle
        transform.position = player.transform.position + new Vector3(xOffset, yOffset, zOffset);
        transform.LookAt(player.transform.position);
    }
}