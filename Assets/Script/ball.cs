using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Field"))
        {
            GetComponent<AudioSource>().Play(); //son de rebond si la balle touche le sol avec le tag Field
        }
    }
}