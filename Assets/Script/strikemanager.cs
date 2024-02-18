using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class strikemanager : MonoBehaviour
{
    public static strikemanager instance;

    public TextMeshProUGUI nbShoot;
    int shoot = 0;

    private void Awake()
    {
        instance = this; //permet de créer une instance pour accéder depuis d'autres scripts
    }

    void Start()
    {
        nbShoot.text = shoot.ToString(); //score à 0
    }

    public void addShoot()
    {
        shoot += 1;
        int temp = PlayerPrefs.GetInt("shot") + 1;
        PlayerPrefs.SetInt("shot", temp); //nombre total de tirs incrémenté
        nbShoot.text = shoot.ToString(); //score incrémenté
    }

    public void resetShoot() //remise du score à 0 lors d'un changement de niveau
    {
        shoot = 0;
        nbShoot.text = shoot.ToString();
    }
}