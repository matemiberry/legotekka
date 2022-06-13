using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ClickDelete : MonoBehaviour
{
	public Button yourButton;
	public static bool active = false;
	

	void Start()
	{
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

    void TaskOnClick()
	{
		if (!active)
		{
			Controller.Mode = Controller.ControllerMode.Build;
			PlaceBrick.MouseInput0 = 1;
			PlaceBrick.MouseInput1 = 0;
			active = true;
		}
	}
}