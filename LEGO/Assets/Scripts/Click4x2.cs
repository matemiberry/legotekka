using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Click4x2 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static int count = 0;
    public Sprite[] newSprite;
    public Sprite[] rotateSprite;
    public Brick[] brick;
    public Material[] mat;
    public UnityEvent onPressAction;
    public static Sprite[] sprites;
    public static Sprite[] spritesRotate;


    private bool _isPressed = false; //фиксируем состояние кнопки (нажата/не нажата)

    //при нажатии
    public void OnPointerDown(PointerEventData eventData)
    {
        sprites = newSprite;
        
        _isPressed = true;

    }
    //при отпускании мыши
    public void OnPointerUp(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = newSprite[count];
        _isPressed = false;
    }

    void Update()
    {
        spritesRotate = rotateSprite;
        //если кнопка нажата, выполняем метод, который задали в инспекторе
        if (_isPressed)
        {
            if (count < brick.Length)
            {
                if (ButtonRotate.active)
                {
                    brick[count].transform.Rotate(Vector3.up, 90);
                    ButtonRotate.active = false;
                }
                
                PlaceBrick.BrickLib = new Brick[] { brick[count] };
                PlaceBrick.MatLib = new Material[] { mat[count] };
                count++;
                Controller.Mode = Controller.ControllerMode.Build;
                
            }
            _isPressed = false;
        }

    }

}

