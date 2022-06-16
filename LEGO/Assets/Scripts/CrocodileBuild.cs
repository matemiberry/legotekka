using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Linq;

public class CrocodileBuild : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
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

    protected Brick[] CrocodileBricks;
    protected Material[] CrocodileMaterials;
    protected Sprite[] CrocodileSprites;
    protected Sprite[] CrocodileSpritesRotate;

    protected int[] TestMat;
    private void Start()
    {
        br = Resources.LoadAll("Bricks", typeof(Brick)).Cast<Brick>().ToArray();
        mtrl = Resources.LoadAll("Materials", typeof(Material)).Cast<Material>().ToArray();
        sprt = Resources.LoadAll("Sprites", typeof(Sprite)).Cast<Sprite>().ToArray();

        CrocodileBricks = new[]
        {
            br[3],br[4],br[4],br[2],br[2],br[5],br[5],br[6],br[2],br[5],
            br[5],br[4],br[2],br[6],br[7],br[7],br[7],br[7],br[6],br[8],
            br[8]
        };

        CrocodileMaterials = new[]
        {
            mtrl[7], mtrl[2], mtrl[2], mtrl[2], mtrl[2], mtrl[2], mtrl[2], mtrl[7], mtrl[2], mtrl[2],
            mtrl[2], mtrl[2], mtrl[3], mtrl[2], mtrl[7], mtrl[7], mtrl[7], mtrl[7], mtrl[2], mtrl[2],
            mtrl[2]
        };
        
        CrocodileSprites = new[]
        {
            sprt[10],sprt[10],sprt[10],sprt[10],sprt[10],sprt[10],sprt[10],sprt[10],sprt[10],sprt[10],
            sprt[10],sprt[10],sprt[10],sprt[10],sprt[10],sprt[10],sprt[10],sprt[10],sprt[10],sprt[10],
            sprt[10]
        };
        CrocodileSpritesRotate = new[]
        {
            sprt[11],sprt[11],sprt[11],sprt[11],sprt[11],sprt[11],sprt[11],sprt[11],sprt[11],sprt[11],
            sprt[11],sprt[11],sprt[11],sprt[11],sprt[11],sprt[11],sprt[11],sprt[11],sprt[11],sprt[11],
            sprt[11]
        };
        
        sprites = CrocodileSprites;
        spritesRotate = CrocodileSpritesRotate;
    }

    // Фиксируем состояние кнопки (нажата/не нажата)
    private bool _isPressed = false; 
    
    //при нажатии
    public void OnPointerDown(PointerEventData eventData)
    {
        sprites = CrocodileSprites;

        _isPressed = true;

    }
    //при отпускании мыши
    public void OnPointerUp(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = CrocodileSprites[count];
        _isPressed = false;
    }
    
    void Update()
    {
        spritesRotate = CrocodileSpritesRotate;
        //если кнопка нажата, выполняем метод, который задали в инспекторе
        if (_isPressed)
        {
            if (count < CrocodileBricks.Length)
            {
                if (ButtonRotate.active)
                {
                    CrocodileBricks[count].transform.localRotation = Quaternion.Euler(0, 90f, 0);
                    ButtonRotate.active = false;

                } else
                {
                    CrocodileBricks[count].transform.localRotation = Quaternion.Euler(0, 0, 0);
                }

                PlaceBrick.BrickLib = new Brick[] { CrocodileBricks[count] };
                PlaceBrick.MatLib = new Material[] { CrocodileMaterials[count] };
                count++;
                Controller.Mode = Controller.ControllerMode.Build;

            }
            _isPressed = false;
        }

    }

}