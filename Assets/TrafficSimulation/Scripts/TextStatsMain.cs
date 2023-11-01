using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TextStatsMain : MonoBehaviour
{
    public TMP_Text MyLabel;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("AutonomousVehicle");
        int enemysCount = enemys.Length;
        Debug.Log(enemysCount);

        MyLabel.text = "Кол-во машин: " + enemysCount.ToString();
    }

    // Update is called once per frame
    // void Update()
    // {

    // }
}
