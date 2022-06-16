using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Linq;

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
    
    public Brick[] br;
    public Material[] mtrl;
    public Sprite[] sprt;
    public Sprite[] sprtside;

    protected Brick[] GiraffeBrick;
    protected Material[] GiraffeMaterial;
    protected Sprite[] GiraffeSprite;
    protected Sprite[] GiraffeSpriteSide;
        private void Start()
    {
        br = Resources.LoadAll("Bricks", typeof(Brick)).Cast<Brick>().ToArray();
        mtrl = Resources.LoadAll("Materials", typeof(Material)).Cast<Material>().ToArray();
        sprt = Resources.LoadAll("SpritesFront", typeof(Sprite)).Cast<Sprite>().ToArray();
        sprtside = Resources.LoadAll("SpritesSide", typeof(Sprite)).Cast<Sprite>().ToArray();
        
        // sprites = Resources.LoadAll("Materials", typeof(Sprite)).Cast<Sprite>().ToArray();
        // spritesRotate = Resources.LoadAll("Materials", typeof(Sprite)).Cast<Sprite>().ToArray();

        GiraffeBrick = new[]
        {
            br[0],br[0],br[0],br[0],br[0],br[1],br[1],br[0],br[0],br[1],br[0]
        };
        
        GiraffeMaterial = new[]
        {
            mtrl[8], mtrl[8], mtrl[8], mtrl[4], mtrl[4], mtrl[8], mtrl[8], mtrl[8], mtrl[8], mtrl[8], mtrl[8]
        };
        
        GiraffeSprite = new[]
        {
            sprt[0], sprt[0], sprt[0], sprt[0], sprt[0], sprt[1],
            sprt[1], sprt[0], sprt[0], sprt[0], sprt[0]
        };

        GiraffeSpriteSide = new[]
        {
            sprtside[0], sprtside[0], sprtside[0], sprtside[0], sprtside[0], sprtside[1],
            sprtside[1], sprtside[0], sprtside[0], sprtside[0], sprtside[0]
        };
        
        sprites = GiraffeSprite;
        spritesRotate = GiraffeSpriteSide;
    }
        
        
    // {Brickname, sprite, sprite_side, x, y, z, ghost, rotate, material} 
    // {Brickname, sprite, sprite_side, x, y, z, ghost, rotate, material}
    
    private bool _isPressed = false; //фиксируем состояние кнопки (нажата/не нажата)
    
    //при нажатии
    public void OnPointerDown(PointerEventData eventData)
    {
        sprites = GiraffeSprite;

        _isPressed = true;

    }
    //при отпускании мыши
    public void OnPointerUp(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = GiraffeSprite[count];
        _isPressed = false;
    }
    
    void Update()
    {
        spritesRotate = GiraffeSpriteSide;
        //если кнопка нажата, выполняем метод, который задали в инспекторе
        if (_isPressed)
        {
            if (count < GiraffeBrick.Length)
            {
                if (ButtonRotate.active)
                {
                    GiraffeBrick[count].transform.localRotation = Quaternion.Euler(0, 90f, 0);
                    ButtonRotate.active = false;

                } else
                {
                    GiraffeBrick[count].transform.localRotation = Quaternion.Euler(0, 0, 0);
                }

                PlaceBrick.BrickLib = new Brick[] { GiraffeBrick[count] };
                PlaceBrick.MatLib = new Material[] { GiraffeMaterial[count] };
                count++;
                Controller.Mode = Controller.ControllerMode.Build;

            }
            _isPressed = false;
        }

    }

}