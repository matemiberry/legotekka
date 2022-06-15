using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistancePlus : MonoBehaviour
{
    public Button yourButton;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    
    void TaskOnClick()
    {
        Controller.distanceToTarget = Mathf.Clamp(Controller.distanceToTarget - 0.5f, 1, 10);
        Vector3 newPosition = Controller.camer.ScreenToViewportPoint(Input.mousePosition);
        Vector3 direction = Controller.previousPosition - newPosition;

        float rotationAroundYAxis = -direction.x * 180;
        float rotationAroundXAxis = direction.y * 180;
        Controller.camer.transform.position = Controller.tar.position;

        Controller.camer.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);

        Controller.camer.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World);

        Controller.camer.transform.Translate(new Vector3(0, 0, -Controller.distanceToTarget));

        Controller.previousPosition = newPosition;
    }
}