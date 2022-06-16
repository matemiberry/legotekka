using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CrocodileBuild : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static int count;
    public UnityEvent onPressAction;
    private bool _isPressed;
    protected Brick[] CrocodileBricks;
    protected Material[] CrocodileMaterials;
    public static Sprite[] CrocodileSprites;
    public static Sprite[] CrocodileSpritesRotate;


    protected int[] TestMat;

    private void Start()
    {
        var br = Resources.LoadAll("Bricks", typeof(Brick)).Cast<Brick>().ToArray();
        var mtrl = Resources.LoadAll("Materials", typeof(Material)).Cast<Material>().ToArray();
        var sprt = Resources.LoadAll("SpritesFront", typeof(Sprite)).Cast<Sprite>().ToArray();
        var spsd = Resources.LoadAll("SpritesSide", typeof(Sprite)).Cast<Sprite>().ToArray();


        CrocodileBricks = new[]
        {
            br[3], br[4], br[4], br[2], br[2], br[5], br[5], br[6], br[2], br[5],
            br[5], br[4], br[2], br[6], br[7], br[7], br[7], br[7], br[6], br[8],
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
            sprt[3], sprt[4], sprt[4], sprt[2], sprt[2], sprt[5], sprt[5], sprt[6], sprt[2], sprt[5],
            sprt[5], sprt[4], sprt[2], sprt[6], sprt[7], sprt[7], sprt[7], sprt[7], sprt[6], sprt[8],
            sprt[8]
        };
        CrocodileSpritesRotate = new[]
        {
            spsd[3], spsd[4], spsd[4], spsd[2], spsd[2], spsd[5], spsd[5], spsd[6], spsd[2], spsd[5],
            spsd[5], spsd[4], spsd[2], spsd[6], spsd[7], spsd[7], spsd[7], spsd[7], spsd[6], spsd[8],
            spsd[8]
        };
    }

    //при нажатии
    public void OnPointerDown(PointerEventData eventData)
    {
        _isPressed = true;
    }

    //при отпускании мыши
    public void OnPointerUp(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = CrocodileSprites[count];
        _isPressed = false;
    }

    private void Update()
    {
        //если кнопка нажата, выполняем метод, который задали в инспекторе
        if (_isPressed)
        {
            if (count < CrocodileBricks.Length)
            {
                CrocodileBricks[count].transform.localRotation =
                    Quaternion.Euler(0, ButtonRotate.rotateButtonCounter * 90, 0);


                PlaceBrick.BrickLib = new[] {CrocodileBricks[count]};
                PlaceBrick.MatLib = new[] {CrocodileMaterials[count]};
                count++;
                Controller.Mode = Controller.ControllerMode.Build;
            }

            _isPressed = false;
        }
    }
}