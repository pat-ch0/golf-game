using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{  
    private int current;

    private void Start()
    {
        current = SceneManager.GetActiveScene().buildIndex; //récupération de la scène active
    }
    private void OnTriggerEnter(Collider other)
    {
        strikemanager.instance.resetShoot(); //on met la balle au point de départ
        SceneManager.LoadScene(current+1); //scène suivante
    }
}
