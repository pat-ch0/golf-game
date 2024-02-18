using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public float rotationSpeed;

    void Update()
    {
        //rotation d'un objet voulu
        transform.Rotate(new Vector3(0, rotationSpeed, 0) * Time.deltaTime);
    }
}