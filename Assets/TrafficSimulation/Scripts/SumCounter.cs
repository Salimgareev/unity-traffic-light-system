using System.Collections;
using System.Collections.Generic;
using TrafficSimulation;
using UnityEngine;
using TMPro;

public class SumCounter : MonoBehaviour
{
    public int road1_sum;
    public int road2_sum;

    private int side1;
    private int side2;
    private int side3;
    private int side4;

    public GameObject intersection;
    public TMP_Text infoText;

    public void refresh_summator(int count, int side)
    {
        if (side == 1)
        {
            side1 = count;
        }
        else if (side == 2)
        {
            side2 = count;
        }
        else if (side == 3)
        {
            side3 = count;
        }
        else if (side == 4)
        {
            side4 = count;
        }

        road1_sum = side1 + side3;
        road2_sum = side2 + side4;

        Intersection interScript = intersection.GetComponent<Intersection>();
        if (road1_sum - road2_sum > 1)
        {  // Увеличиваем время на стороне 1
            interScript.lightsDuration = 15;
            interScript.lightsDuration2 = 2;
        }
        else if (road2_sum - road1_sum > 1)
        { // Увеличиваем время на стороне 2
            interScript.lightsDuration = 2;
            interScript.lightsDuration2 = 15;
        }
        else
        { // Одинаково
            interScript.lightsDuration = 10;
            interScript.lightsDuration2 = 10;
        }

        GameObject GM = GameObject.Find("Button");
        Electricity electrScript = GM.GetComponent<Electricity>();
        if (electrScript.turnOn)
        {
            infoText.text = "Перекресток 1:\n" +
            interScript.lightsDuration.ToString() +
            "/" + interScript.lightsDuration2.ToString();
        }
        else
        {
            infoText.text = "Перекресток 1:\n0/0";
        }


    }
}
