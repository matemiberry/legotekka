using System;
using System.Collections;
using UnityEngine;

public class Controller : MonoBehaviour
{

    //Input
    protected Player Player;

    //Parameters
    protected const float RotationSpeed = 100;

    //Camera Controll
    public Vector3 CameraPivot;
    public float CameraDistance;

    public RingMenu MainMenuPrefab;
    protected RingMenu MainMenuInstance;

    protected float InputRotationX;
    protected float InputRotationY;

    protected Vector3 CharacterPivot;
    protected Vector3 LookDirection;

    protected Vector3 LastMousePos;
    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;
    [SerializeField] private float distanceToTarget;
    
    private Vector3 previousPosition;
    
    public static ControllerMode Mode;

    // Use this for initialization
    void Start()
    {
        SetMode(ControllerMode.Play);
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Mathf.Clamp(distanceToTarget + Input.mouseScrollDelta.y, 1, 10);
        
        // if (Mode == ControllerMode.Play)
        // {
        //     if (Input.GetKeyDown(KeyCode.Tab))
        //     {
        //         SetMode(ControllerMode.Build);
        //     }
        // }
        // else if (Mode == ControllerMode.Build || Mode == ControllerMode.Menu)
        // {
        //     if (Input.GetKeyDown(KeyCode.Tab))
        //     {
        //         SetMode(ControllerMode.Play);
        //     }
        // }
        
        // if (Mode == ControllerMode.Play)
        // {
        //     //scroll to zoom
        //     CameraDistance = Mathf.Clamp(CameraDistance + Input.mouseScrollDelta.y, 0, 10);
        //
        //     //input
        //     InputRotationX = InputRotationX + Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime % 360f;
        // InputRotationY = Mathf.Clamp(InputRotationY - Input.GetAxis("Mouse Y") * RotationSpeed * Time.deltaTime, 0f, 88f);
        //
        //     //left and forward
        //     var characterForward = Quaternion.AngleAxis(InputRotationX, Vector3.up) * Vector3.forward;
        //     var characterLeft = Quaternion.AngleAxis(InputRotationX + 90, Vector3.up) * Vector3.forward;
        //
        //     //look and run direction
        //     var runDirection = characterForward * Input.GetAxisRaw("Vertical") + characterLeft * Input.GetAxisRaw("Horizontal");
        // LookDirection = Quaternion.AngleAxis(InputRotationY, characterLeft) * characterForward;
        //     
        //     CharacterPivot = Quaternion.AngleAxis(InputRotationX, Vector3.up) * CameraPivot;
        //
        // }
        
        if (Mode == ControllerMode.Build)
        {
            if (Input.GetMouseButtonDown(0))
            {
                previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            }
        }

        if (Mode == ControllerMode.Play)
        {
            // distanceToTarget = Mathf.Clamp(distanceToTarget + Input.mouseScrollDelta.y, 0, 10);
            
            if (Input.GetMouseButtonDown(0))
            {
                previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            }
            else if (Input.GetMouseButton(0))
            {
                Vector3 newPosition = cam.ScreenToViewportPoint(Input.mousePosition);
                Vector3 direction = previousPosition - newPosition;
            
                float rotationAroundYAxis = -direction.x * 180; // camera moves horizontally
                float rotationAroundXAxis = direction.y * 180; // camera moves vertically
                cam.transform.position = target.position;

                cam.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
                
                cam.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World); // <— This is what makes it work!
            
                cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));
            
                previousPosition = newPosition;
            }
        }
    }

    public void SetMode(ControllerMode mode)
    {
        Mode = mode;
        if (mode != ControllerMode.Menu && MainMenuInstance != null)
            Destroy(MainMenuInstance);

        switch (mode)
        {
            case ControllerMode.Build:
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            // case ControllerMode.Menu:
            //     Cursor.lockState = CursorLockMode.None;
            //     Cursor.visible = true;
            //     break;
            case ControllerMode.Play:
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
        }
    }
    
    private void LateUpdate()
    {
        // //set camera values
        // Camera.main.transform.position = (transform.position + CharacterPivot) - LookDirection * CameraDistance;
        // Camera.main.transform.rotation = Quaternion.LookRotation(LookDirection, Vector3.up);
    }

    public enum ControllerMode
    {
        Play,
        Build,
        Menu
    }
}