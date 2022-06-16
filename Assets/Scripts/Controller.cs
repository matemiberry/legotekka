using UnityEngine;

public class Controller : MonoBehaviour
{
    //Camera Controll
    public static Camera camer;
    public static Transform tar;
    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;
    public static float distanceToTarget = 5;
    //public static float distant;
    
    public static Vector3 previousPosition;
    public static ControllerMode Mode;

    // Use this for initialization
    void Start()
    {
        SetMode(ControllerMode.Play);
        camer = cam;
        tar = target;
    }

    // Update is called once per frame
    void Update()
    {
        tar = target;
        camer = cam;
        distanceToTarget = Mathf.Clamp(distanceToTarget + Input.mouseScrollDelta.y, 1, 10);

        if (Mode == ControllerMode.Build)
        {
            if (Input.GetMouseButtonDown(0))
            {
                previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            }
        }

        if (Mode == ControllerMode.Play)
        {   
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
                cam.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World); 
                cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));
                previousPosition = newPosition;
            }
        }
    }

    public void SetMode(ControllerMode mode)
    {
        Mode = mode;
        switch (mode)
        {
            case ControllerMode.Build:
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            case ControllerMode.Play:
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
        }
    }

    public enum ControllerMode
    {
        Play,
        Build,
    }
}