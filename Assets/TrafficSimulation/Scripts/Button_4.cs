using System.Collections;
using System.Collections.Generic;
using TrafficSimulation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Button_4 : MonoBehaviour
{
    public Button yourButton;
    public Intersection inter;

    void Start()
    {
        yourButton = yourButton.GetComponent<Button>();
        yourButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        // GameObject GM = GameObject.Find("Intersection-4");
        // Intersection inter = GM.GetComponent<Intersection>();
        // inter.intersectionType = IntersectionType.STOP;
        GameObject[] lights = GameObject.FindGameObjectsWithTag("TrafficLight");


        foreach (GameObject obj in lights)
        {
            RedLightStatus redLight = obj.GetComponent<RedLightStatus>();

            if (redLight.intersection.name == inter.name)
            {
                if (redLight.isManualLightOn == false)
                {
                    redLight.isManualLightOn = true;

                }
                else
                {
                    redLight.isManualLightOn = false;
                }

                Debug.Log(obj.name);
            }
        }
    }
}
