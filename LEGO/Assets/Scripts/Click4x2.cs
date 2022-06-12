using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Click4x2 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    protected int count = 0;
    public Sprite[] newSprite;
    public Brick[] brick;
    public Material[] mat;
    public UnityEvent onPressAction;


    private bool _isPressed = false; //фиксируем состояние кнопки (нажата/не нажата)

    //при нажатии
    public void OnPointerDown(PointerEventData eventData)
    {
        _isPressed = true;
    }
    //при отпускании мыши
    public void OnPointerUp(PointerEventData eventData)
    {
        _isPressed = false;
        GetComponent<Image>().sprite = newSprite[count];
    }

    void Update()
    {
        //если кнопка нажата, выполняем метод, который задали в инспекторе
        if (_isPressed)
        {
            if (count < brick.Length)
            {
                PlaceBrick.BrickLib = new Brick[] { brick[count] };
                PlaceBrick.MatLib = new Material[] { mat[count] };
                count++;
                Controller.Mode = Controller.ControllerMode.Build;
                
            }
            _isPressed = false;
        }
    }

}

