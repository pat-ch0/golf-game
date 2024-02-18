using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public Rigidbody rb;
    Vector3 originalPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //on sauvegarde la position de départ
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }
    void Update()
    {
        //si appui sur "entrée", la balle revient au départ avec une vitesse nulle
        if (Input.GetKeyDown(KeyCode.Return))
        {
            gameObject.transform.position = originalPos;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}