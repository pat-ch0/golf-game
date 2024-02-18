using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBound : MonoBehaviour
{
    Vector3 originalPos;
    public GameObject ball;

    void Start()
    {
        ball = GameObject.Find("Ball");
        originalPos = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        ball.transform.position = originalPos;
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}