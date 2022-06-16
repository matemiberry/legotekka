using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeChange : MonoBehaviour
{
    public Button buttonModeChanger;

    private void Start()
    {
        Button btn = buttonModeChanger.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {
        if (PlaceBrick.MouseInput0 == 0 && PlaceBrick.MouseInput1 == 1)
        {
            PlaceBrick.MouseInput0 = 1;
            PlaceBrick.MouseInput1 = 0;
        }
        else
        {
            PlaceBrick.MouseInput0 = 0;
            PlaceBrick.MouseInput1 = 1;
        }
    }
}