using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegoBuilder : MonoBehaviour
{
    public List<GameObject> bricksList;
    public static int count = 0;
    readonly object[,] giraffeScheme = new object[11, 2]
    {
        {"Clone0", new Vector3(-0.2f, 0f, 0.7f)},
        {"Clone1", new Vector3(-0.2f, 0f, 0.3f)},
        {"Clone2", new Vector3(-0.2f, 0.24f, 0.3f)},
        {"Clone3", new Vector3(-0.2f, 0.24f, 0.7f)},
        {"Clone4", new Vector3(-0.2f, 0.48f, 0.3f)},
        {"Clone5", new Vector3(-0.2f, 0.48f, 0.6f)},
        {"Clone6", new Vector3(-0.2f, 0.72f, 0.4f)},
        {"Clone7", new Vector3(-0.2f, 0.96f, 0.3f)},
        {"Clone8", new Vector3(-0.2f, 1.2f, 0.3f)},
        {"Clone9", new Vector3(-0.2f, 1.44f, 0.2f)},
        {"Clone10", new Vector3(-0.2f, 1.68f, 0.3f)}
    };


    void Start()
    {
        bricksList = new List<GameObject>(Resources.LoadAll<GameObject>("Bricks"));
        Instantiate(bricksList[3], (Vector3)giraffeScheme[0, 1], Quaternion.identity);
    }

    // Clone0, -0.2f, 0f, 0.7f
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
        if (GameObject.Find((string)giraffeScheme[count, 0]) != null)
        {
            if (GameObject.Find((string)giraffeScheme[count, 0]).transform.position == (Vector3)giraffeScheme[count, 1] && Input.GetMouseButtonUp(0))
            {
                if (count != giraffeScheme.Length)
                {
                    if (count == 4 || count == 5 || count == 8)
                    {
                        Instantiate(bricksList[4], (Vector3)giraffeScheme[count + 1, 1], Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(bricksList[3], (Vector3)giraffeScheme[count + 1, 1], Quaternion.identity);
                    }
                    count++;
                }
            }
        }
    }
}