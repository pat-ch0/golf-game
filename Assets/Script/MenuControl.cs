using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    public Camera cam;

    private void Start()
    {
        cam.backgroundColor = Color.black;

    }
    public void QuitApplication() //quitter
    {
        PlayerPrefs.DeleteKey("shot");
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void ChangeScene() //jouer
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<music>().PlayMusic();
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("shot", 0);
    }
}
