using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using TrafficSimulation;

public class TextStatsMain : MonoBehaviour
{
    public TMP_Text infoText;

    // public TextMesh averageSpeedText;
    public float updateInterval = 1.0f;  // Интервал обновления в секундах

    private float timeLeft;

    public float totalEnergyCost = 0.0f;
    public float wattagePerLight = 30.0f; // Мощность светодиодных ламп в ваттах
    public float electricityRate = 4.81f; // Тариф на электроэнергию в рублях за кВт/час


    // Start is called before the first frame update
    void Start()
    {
        timeLeft = updateInterval;
        // CalculateAverageSpeedAndVehicleCount();
        // GameObject[] enemys = GameObject.FindGameObjectsWithTag("AutonomousVehicle");
        // int enemysCount = enemys.Length;
        // Debug.Log(enemysCount);

        // MyLabel.text = "Кол-во машин: " + enemysCount.ToString();
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            CalculateAverageSpeedAndVehicleCount();
            timeLeft = updateInterval;
        }
    }

    private void CalculateAverageSpeedAndVehicleCount()
    {
        GameObject[] vehicles = GameObject.FindGameObjectsWithTag("AutonomousVehicle");
        if (vehicles.Length == 0)
        {
            infoText.text = "Ср. скорость: N/A\nКол-во машин: 0";
            return;
        }

        float totalSpeed = 0f;

        foreach (GameObject vehicle in vehicles)
        {
            WheelDrive wheelDrive = vehicle.GetComponent<WheelDrive>();
            if (wheelDrive != null)
            {
                float speed = wheelDrive.GetSpeedUnit(vehicle.GetComponent<Rigidbody>().velocity.magnitude);
                totalSpeed += speed;
            }
        }

        float averageSpeed = totalSpeed / vehicles.Length * 7;  // 7 - коэфф. скорости
        int vehicleCount = vehicles.Length;


        GameObject[] trafficLights = GameObject.FindGameObjectsWithTag("TrafficLight"); // Получить все светофоры
        float totalEnergyConsumption = 0.0f;


        foreach (var trafficLight in trafficLights)
        {
            var redLightStatus = trafficLight.GetComponent<RedLightStatus>();
            totalEnergyConsumption += redLightStatus.CalculateElectricityConsumption(wattagePerLight);
            totalEnergyCost += (totalEnergyConsumption / 3600) * electricityRate;
        }

        // float totalEnergyCost = totalEnergyConsumption * electricityRate;


        // infoText.text = "Средняя скорость: " + averageSpeed.ToString("F2") + " " + (vehicles[0].GetComponent<WheelDrive>().unitType == UnitType.KMH ? "км/ч" : "mph") + "\nКол-во машин: " + vehicleCount;

        infoText.text = "Кол-во машин: " + vehicleCount
         + "\nСр. скорость: " + averageSpeed.ToString("F2")
         + " " + (vehicles[0].GetComponent<WheelDrive>().unitType == UnitType.KMH ? "км/ч" : "mph")
         + "\nОбщ. потребление: " + totalEnergyConsumption.ToString("F3") 
         + " кВтч" + "\nОбщ. стоимость: " + (totalEnergyCost).ToString("F3") + " руб";

    }
}

