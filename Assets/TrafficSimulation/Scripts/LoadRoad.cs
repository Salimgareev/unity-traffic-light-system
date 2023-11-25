using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadRoad : MonoBehaviour
{
    public int carCount;
    public TMP_Text infoText;

    public void addCar(int cnt){
        carCount = carCount + cnt;
        if (carCount < 0) {
            carCount = 0;
        }
        infoText.text = carCount.ToString();
    }

}
