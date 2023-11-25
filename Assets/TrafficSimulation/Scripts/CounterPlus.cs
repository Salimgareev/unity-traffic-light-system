using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterPlus : MonoBehaviour
{
    public GameObject roadLoad;
    public bool plus = true;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Start counter");
        LoadRoad counter = roadLoad.GetComponent<LoadRoad>();
        if (plus)
        {
            counter.addCar(1);
        }
        else
        {
            counter.addCar(-1);
        }
    }
}
