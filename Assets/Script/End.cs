using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public TextMeshProUGUI shot;

    public void Start()
    {
        //trouve l'élément audio associé au gameobject avec le tag Music
        GameObject.FindGameObjectWithTag("Music").GetComponent<music>().StopMusic();
        int name = PlayerPrefs.GetInt("shot");
        if (name <= 6) //si on fait tous les levels en one shot, on a un point d'exclamation
        {
            shot.text = PlayerPrefs.GetInt("shot").ToString() + " shots !";
        }
        else
        {
            shot.text = PlayerPrefs.GetInt("shot").ToString() + " shots";
        }
    }

    public void QuitApplication() //quitter
    {
        PlayerPrefs.DeleteKey("shot");
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void Restart() //rejouer
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<music>().PlayMusic();
        SceneManager.LoadScene("level1");
        PlayerPrefs.SetInt("shot", 0);
    }
}