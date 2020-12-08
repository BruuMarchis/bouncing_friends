using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setPoints : MonoBehaviour
{
    public Text pontos;
    void Start()
    {
        if (GameManager.points < 0)
        {
            GameManager.points = 0;
        }
        int gamepoints = GameManager.points;
        pontos.text = "" + gamepoints.ToString() + " pontos!";
    }
}
