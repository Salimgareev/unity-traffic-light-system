using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadRoad : MonoBehaviour
{
    public int carCount;
    public TMP_Text infoText;
    public GameObject summator;
    public int side;

    public void addCar(int cnt){
        carCount = carCount + cnt;
        if (carCount < 0) {
            carCount = 0;
        }

        GameObject GM = GameObject.Find("Button");
        Electricity electrScript = GM.GetComponent<Electricity>();
        if (electrScript.turnOn) {
            infoText.text = carCount.ToString();
        } else {
            infoText.text = "";
        }
        SumCounter sumCounter = summator.GetComponent<SumCounter>();
        sumCounter.refresh_summator(carCount, side);
    }

}
