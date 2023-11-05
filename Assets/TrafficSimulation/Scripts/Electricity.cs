using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Electricity : MonoBehaviour
{
    public bool turnOn = true;
    public Button yourButton;

	void Start () {
		// Button btn = yourButton.GetComponent<Button>();
		// btn.onClick.AddListener(TaskOnClick);

        yourButton = yourButton.GetComponent<Button>();
		yourButton.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		if (turnOn)
        {
            turnOn = false;
            yourButton.GetComponentInChildren<TMP_Text>().text = "Вкл свет";
        }
        else
        {
            turnOn = true;
            yourButton.GetComponentInChildren<TMP_Text>().text = "Выкл свет";
        }
	}
}
