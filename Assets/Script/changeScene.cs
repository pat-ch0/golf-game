using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{  
    private int current;

    private void Start()
    {
        current = SceneManager.GetActiveScene().buildIndex; //r�cup�ration de la sc�ne active
    }
    private void OnTriggerEnter(Collider other)
    {
        strikemanager.instance.resetShoot(); //on met la balle au point de d�part
        SceneManager.LoadScene(current+1); //sc�ne suivante
    }
}
