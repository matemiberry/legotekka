using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ButtonRotate : MonoBehaviour
{
    public Button yourButton;
    public static bool active = false;
    public Button curButton;
    public static int rotateButtonCounter = 0; 
    
    // Start is called before the first frame update
    private void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    private void TaskOnClick()
    {
        rotateButtonCounter++;
        Debug.Log(rotateButtonCounter);
        
        if (!active)
        {
            active = true;
            if (SceneManager.GetActiveScene().name == "GiraffeScene")
            {
                curButton.GetComponent<Image>().sprite = Click4x2.GiraffeSpriteSide[Click4x2.count];
            } else if (SceneManager.GetActiveScene().name == "CrocodileScene")
            {
                curButton.GetComponent<Image>().sprite = CrocodileBuild.CrocodileSpritesRotate[CrocodileBuild.count];
            }

        } 
        else {
            if (SceneManager.GetActiveScene().name == "GiraffeScene")
            {
                curButton.GetComponent<Image>().sprite = Click4x2.GiraffeSprite[Click4x2.count];
            } 
            else if (SceneManager.GetActiveScene().name == "CrocodileScene")
            {
                curButton.GetComponent<Image>().sprite = CrocodileBuild.CrocodileSprites[CrocodileBuild.count];
            }
            active = false;
        }
    }
}