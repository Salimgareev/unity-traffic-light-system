// Traffic Simulation
// https://github.com/mchrbn/unity-traffic-simulation

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TrafficSimulation;

public class RedLightStatus : MonoBehaviour
{

    public bool isLightOn = true; // По умолчанию светофор включен

    public bool isManualLightOn = true;   // Светофор включен
    public int lightGroupId;  // Belong to traffic light 1 or 2?
    public Intersection intersection;

    Light pointLight;

    void Start()
    {
        pointLight = this.transform.GetChild(0).GetComponent<Light>();
        SetTrafficLightColor();
    }

    // Update is called once per frame
    void Update()
    {
        SetTrafficLightColor();
    }

    void SetTrafficLightColor()
    {
        if (isLightOn && isManualLightOn)
        {

            if (lightGroupId == intersection.currentRedLightsGroup)
                pointLight.color = new Color(1, 0, 0);
            else
                pointLight.color = new Color(0, 1, 0);
        }
        else
        {
            pointLight.color = new Color(0, 0, 0);
        }

        GameObject GM = GameObject.Find("Button");
        Electricity electr = GM.GetComponent<Electricity>();
        if (electr.turnOn && isManualLightOn)
        {
            isLightOn = true;
            if (intersection.isElectr){
                intersection.intersectionType = IntersectionType.TRAFFIC_LIGHT;
            }
        }
        else
        {
            isLightOn = false;
            if (intersection.isElectr){
                intersection.intersectionType = IntersectionType.STOP;
            }
        }
    }

    public float CalculateElectricityConsumption(float wattagePerLight)
    {
        if (isLightOn)
        {
            // float energyConsumption = (Time.deltaTime / 3600.0f) * wattagePerLight; // Потребление в кВт*ч
            float energyConsumption = wattagePerLight / 1000;
            // Debug.Log(energyConsumption);
            return energyConsumption;
        }
        else
        {
            return 0.0f; // Если светофор выключен, потребление равно нулю
        }
    }

}
