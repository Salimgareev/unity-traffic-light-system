using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Button_Fix_Script : MonoBehaviour
{
    public Button yourButton;

    void Start()
    {
        yourButton = yourButton.GetComponent<Button>();
        yourButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("PlusError");
        if (GM == null)
        {
            GM = FindInActiveObjectByTag("PlusError");
        }
        if (GM == null)
        {
            return;
        }

        if (GM.activeSelf)
        {
            GM.SetActive(false);
            yourButton.GetComponentInChildren<TMP_Text>().text = "Починить";
        }
        else
        {
            GM.SetActive(true);
            yourButton.GetComponentInChildren<TMP_Text>().text = "Сломать датчик";
        }

        Debug.Log(GM.activeSelf);
    }

    GameObject FindInActiveObjectByTag(string tag)
    {

        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].CompareTag(tag))
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }
}
