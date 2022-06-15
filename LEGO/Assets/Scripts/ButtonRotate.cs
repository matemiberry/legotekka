using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonRotate : MonoBehaviour
{
    public Button yourButton;
    public static bool active = false;
    public Button curButton;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void TaskOnClick()
    {
        if (!active)
        {
            active = true;
            curButton.GetComponent<Image>().sprite = Click4x2.spritesRotate[Click4x2.count];
        } else
        {
            curButton.GetComponent<Image>().sprite = Click4x2.sprites[Click4x2.count];
            active = false;
        }
    }
}