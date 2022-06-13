using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegoBuilder : MonoBehaviour
{
    public List<GameObject> bricksList;
    // Start is called before the first frame update
    
    readonly object[,] giraffeScheme = new object[11,2]
    {
        {"0(Clone)", new Vector3(-0.2f, 0f, 0.7f)},
        {"0(Clone)", new Vector3(-0.2f, 0f, 0.3f)},
        {"0(Clone)", new Vector3(-0.2f, 0.24f, 0.3f)},
        {"0(Clone)", new Vector3(-0.2f, 0.24f, 0.7f)},
        {"0(Clone)", new Vector3(-0.2f, 0.48f, 0.3f)},
        {"1(Clone)", new Vector3(-0.2f, 0.48f, 0.6f)},
        {"1(Clone)", new Vector3(-0.2f, 0.72f, 0.4f)},
        {"0(Clone)", new Vector3(-0.2f, 0.96f, 0.3f)},
        {"0(Clone)", new Vector3(-0.2f, 1.2f, 0.3f)},
        {"1(Clone)", new Vector3(-0.2f, 1.44f, 0.2f)},
        {"0(Clone)", new Vector3(-0.2f, 1.68f, 0.3f)}
    };
    

    void Start()
    {
        bricksList = new List<GameObject>(Resources.LoadAll<GameObject>("Bricks"));
        Instantiate(bricksList[3], (Vector3) giraffeScheme[0,1], Quaternion.identity);
    }

    // 0, -0.2f, 0f, 0.7f
    // 0, -0.2f, 0f, 0.3f
    // 0, -0.2f, 0.24f, 0.3f
    // 0, -0.2f, 0.24f, 0.7f
    // 0, -0.2f, 0.48f, 0.3f
    // 1, -0.2f, 0.48f, 0.6f
    // 1, -0.2f, 0.72f, 0.4f
    // 0, -0.2f, 0.96f, 0.3f
    // 0, -0.2f, 1.2f, 0.3f
    // 1, -0.2f, 1.44f, 0.2f
    // 0, -0.2f, 1.68f, 0.3f
    
    // Update is called once per frame
    void Update()
    {
        // for (int i = 0; i <= giraffeScheme.Length;)
        // {
        //     
        // }
        if (GameObject.Find((string) giraffeScheme[0,0]).transform.position == (Vector3) giraffeScheme[0,1] && Input.GetMouseButtonUp(0))
        {
            GameObject.Find("3(Clone)").transform.position = (Vector3) giraffeScheme[1,1];
        }
    }
}