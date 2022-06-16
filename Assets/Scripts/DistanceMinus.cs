using UnityEngine;
using UnityEngine.UI;

public class DistanceMinus : MonoBehaviour
{
    public Button yourButton;

    private void Start()
    {
        var btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        Controller.distanceToTarget = Mathf.Clamp(Controller.distanceToTarget + 0.5f, 1, 10);

        var newPosition = Controller.camer.ScreenToViewportPoint(Input.mousePosition);
        var direction = Controller.previousPosition - newPosition;

        var rotationAroundYAxis = -direction.x * 180;
        var rotationAroundXAxis = direction.y * 180;
        Controller.camer.transform.position = Controller.tar.position;

        Controller.camer.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);

        Controller.camer.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World);

        Controller.camer.transform.Translate(new Vector3(0, 0, -Controller.distanceToTarget));

        Controller.previousPosition = newPosition;
    }
}