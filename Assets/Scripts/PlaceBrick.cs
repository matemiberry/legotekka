using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlaceBrick : MonoBehaviour
{
    public static Brick[] BrickLib;
    public static Material[] MatLib;
    protected Brick PrefabBrick;
    public Material TransparentMat;
    protected Material BrickMat;
    public static int counter;
    protected Controller Controller;
    public static Brick CurrentBrick;
    protected bool PositionOk;

    protected ModeChange ModeChange;

    public static int MouseInput0;
    public static int MouseInput1 = 1;
    public Button curButton;

    public AudioSource brickPlaceSound;
    public AudioSource brickDeleteSound;

    private void Awake()
    {
        Controller = GetComponent<Controller>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (BrickLib != null && MatLib != null)
        {
            PrefabBrick = BrickLib[0];
            BrickMat = MatLib[0];
        }

        if (Controller.Mode != Controller.ControllerMode.Build)
        {
            if (CurrentBrick != null)
                Destroy(CurrentBrick.gameObject);
            return;
        }

        if (CurrentBrick == null)
            SetNextBrick();

        if (CurrentBrick != null)
        {
            RaycastHit hitInfo;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitInfo))
            {
                // Snap to grid
                var position = LegoLogic.SnapToGrid(hitInfo.point);

                // Try to find a collision free position
                var placePosition = position;
                var rotation = CurrentBrick.transform.rotation;

                // 1x2 Brick fix
                if (CurrentBrick.name == "0(Clone)" && (rotation.y is 0 || Math.Abs(rotation.y) is 1))
                    placePosition.z = placePosition.z + 0.1f;
                else if (CurrentBrick.name == "0(Clone)") placePosition.x = placePosition.x + 0.1f;

                // 1x1 Brick and Stud fix
                if (CurrentBrick.name == "7(Clone)" || CurrentBrick.name == "8(Clone)")
                {
                    placePosition.z = placePosition.z + 0.1f;
                    placePosition.x = placePosition.x + 0.1f;
                }

                // 2x6 Brick/Plate fix
                if ((CurrentBrick.name == "4(Clone)" || CurrentBrick.name == "6(Clone)") &&
                    (CurrentBrick.transform.rotation.y is 0 || Math.Abs(CurrentBrick.transform.rotation.y) is 1))
                    placePosition.x = placePosition.x + 0.1f;
                else if (CurrentBrick.name == "4(Clone)" || CurrentBrick.name == "6(Clone)")
                    placePosition.z = placePosition.z + 0.1f;

                PositionOk = false;
                for (var i = 0; i < 10; i++)
                {
                    var collider = Physics.OverlapBox(
                        placePosition + CurrentBrick.transform.rotation * CurrentBrick.Collider.center,
                        CurrentBrick.Collider.size / 2, CurrentBrick.transform.rotation, LegoLogic.LayerMaskLego);
                    PositionOk = collider.Length == 0;
                    if (PositionOk)
                        break;
                    placePosition.y += LegoLogic.Grid.y;
                }

                CurrentBrick.transform.position = PositionOk ? placePosition : position;
            }
        }


        // Place Brick
        if (Input.GetMouseButtonUp(MouseInput0) && CurrentBrick != null && PositionOk)
        {
            CurrentBrick.Collider.enabled = true;
            CurrentBrick.name = "Clone" + counter;
            counter++;
            CurrentBrick.SetMaterial(BrickMat);

            ButtonRotate.rotateButtonCounter = 0;
            ButtonRotate.active = false;

            CurrentBrick = null;
            brickPlaceSound.Play();
            SetNextBrick();
            Controller.Mode = Controller.ControllerMode.Play;
        }

        // Rotate Brick
        if (Input.GetKeyDown(KeyCode.E))
            CurrentBrick.transform.Rotate(Vector3.up, 90);

        // Delete Brick
        if (Input.GetMouseButtonDown(MouseInput1))
        {
            RaycastHit hitInfo;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo))
            {
                var brick = hitInfo.collider.GetComponent<Brick>();
                if (brick != null)
                {
                    DestroyImmediate(brick.gameObject);
                    brickDeleteSound.Play();
                    MouseInput0 = 0;
                    MouseInput1 = 1;
                    Controller.Mode = Controller.ControllerMode.Play;
                    ClickDelete.active = false;
                    if (SceneManager.GetActiveScene().name == "GiraffeScene")
                    {
                        Click4x2.count--;
                        curButton.GetComponent<Image>().sprite = Click4x2.GiraffeSprite[Click4x2.count];
                    }
                    else if (SceneManager.GetActiveScene().name == "CrocodileScene")
                    {
                        CrocodileBuild.count--;
                        curButton.GetComponent<Image>().sprite = CrocodileBuild.CrocodileSprites[CrocodileBuild.count];
                    }

                    counter--;
                }
            }
        }
    }

    public void SetNextBrick()
    {
        CurrentBrick = Instantiate(PrefabBrick);
        CurrentBrick.Collider.enabled = false;
        CurrentBrick.SetMaterial(TransparentMat);
    }

    public void SetPrefab(int brick, int mat)
    {
        PrefabBrick = BrickLib[brick];
        BrickMat = MatLib[mat];
    }
}