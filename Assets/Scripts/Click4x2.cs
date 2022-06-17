using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Click4x2 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static int count = 0;
    public UnityEvent onPressAction;

    private bool _isPressed;
    protected Brick[] GiraffeBrick;
    protected Material[] GiraffeMaterial;
    public static Sprite[] GiraffeSprite;
    public static Sprite[] GiraffeSpriteSide;

    private void Start()
    {
        count = 0;
        var br = Resources.LoadAll("Bricks", typeof(Brick)).Cast<Brick>().ToArray();
        var mtrl = Resources.LoadAll("Materials", typeof(Material)).Cast<Material>().ToArray();
        var sprt = Resources.LoadAll("SpritesFront", typeof(Sprite)).Cast<Sprite>().ToArray();
        var sprtside = Resources.LoadAll("SpritesSide", typeof(Sprite)).Cast<Sprite>().ToArray();

        GiraffeBrick = new[]
        {
            br[0], br[0], br[0], br[0], br[0], br[1], br[1], br[0], br[0], br[1], br[0]
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
    }

    //при нажатии
    public void OnPointerDown(PointerEventData eventData)
    {
        _isPressed = true;
    }

    //при отпускании мыши
    public void OnPointerUp(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = GiraffeSprite[count];
        _isPressed = false;
    }

    private void Update()
    {
        if (_isPressed)
        {
            if (count < GiraffeBrick.Length)
            {
                if (ButtonRotate.active)
                {
                    GiraffeBrick[count].transform.localRotation = Quaternion.Euler(0, 90f, 0);
                    ButtonRotate.active = false;
                }
                else
                {
                    GiraffeBrick[count].transform.localRotation = Quaternion.Euler(0, 0, 0);
                }

                PlaceBrick.BrickLib = new[] {GiraffeBrick[count]};
                PlaceBrick.MatLib = new[] {GiraffeMaterial[count]};
                count++;
                Controller.Mode = Controller.ControllerMode.Build;
            }

            _isPressed = false;
        }
    }
}