using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegoBuilder : MonoBehaviour
{
    private Vector3 checkPos = new Vector3(0f, 0.1f, -0.5f);
    private float checkRad = 0.001f;
    
    public List<GameObject> bricksList;
    // Start is called before the first frame update
    void Start()
    {
        bricksList = new List<GameObject>(Resources.LoadAll<GameObject>("Bricks"));
        
        Instantiate(bricksList[3], new Vector3(-0.2f, 0f, 0.7f), Quaternion.identity);
        
    }

    // 1x2, -0.2, 0, 0.7
    // 1x2, -0.2, 0, 0.3
    // 1x2, -0.2, 0.24, 0.3
    // 1x2, -0.2, 0.24, 0.7
    // 1x2, -0.2, 0.48, 0.3
    // 2x2, -0.2, 0.48, 0.6
    // 2x2, -0.2, 0.72, 0.4
    // 1x2, -0.2, 0.96, 0.3
    // 1x2, -0.2, 1.2, 0.3
    // 2x2, -0.2, 1.44, 0.2
    // 1x2, -0.2, 1.68, 0.3
    
    // Update is called once per frame
    void Update()
    {
        // Vector3 checkBrick = new Vector3(0f, 0f, -0.5f);
        // if (Physics.CheckSphere(checkPos, checkRad))
        // {
        //     Debug.Log(GameObject.Find("PrefabBrick3(Clone)").transform.position.z.GetType());
        // }
        
        if (GameObject.Find("PrefabBrick3(Clone)").transform.position == new Vector3(-0.2f, 0f, 0.7f))
        {
            GameObject.Find("3(Clone)").transform.position = new Vector3(-0.2f, 0f, 0.3f);
        }
        else
        {

        }
    }
}