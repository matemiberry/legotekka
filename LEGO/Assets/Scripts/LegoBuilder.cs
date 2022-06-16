using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using System.Linq;
using Object = UnityEngine.Object;

public class LegoBuilder : MonoBehaviour
{
    public GameObject[] bricksList;
    public static int count;

    private readonly object[,] giraffeScheme = new object[11, 2]
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

    private readonly object[,] crocodileScheme = new object[21, 4]
    {
        // { CloneName, Position, Rotation, GhostBrickName }
        {"Clone0", new Vector3(-0.2f, 0.0f, -0.2f), Quaternion.Euler(0, 0, 0), 3},
        {"Clone1", new Vector3(-0.5f, 0.1f, -0.2f), Quaternion.Euler(0, 0, 0), 4},
        {"Clone2", new Vector3(0.1f, 0.1f, -0.2f), Quaternion.Euler(0, 0, 0), 4},
        {"Clone3", new Vector3(0.6f, 0.1f, -0.2f), Quaternion.Euler(0, 90, 0), 2},
        {"Clone4", new Vector3(-1.0f, 0.1f, -0.2f), Quaternion.Euler(0, 90, 0), 2},
        {"Clone5", new Vector3(0.0f, 0.3f, -0.2f), Quaternion.Euler(0, 180, 0), 5},
        {"Clone6", new Vector3(0.4f, 0.3f, -0.2f), Quaternion.Euler(0, 0, 0), 5},
        {"Clone7", new Vector3(1.1f, 0.0f, -0.2f), Quaternion.Euler(0, 0, 0), 6},
        {"Clone8", new Vector3(1.2f, 0.1f, -0.2f), Quaternion.Euler(0, 0, 0), 2},
        {"Clone9", new Vector3(0.8f, 0.3f, -0.2f), Quaternion.Euler(0, 180, 0), 5},
        {"Clone10", new Vector3(1.2f, 0.3f, -0.2f), Quaternion.Euler(0, 0, 0), 5},
        {"Clone11", new Vector3(-0.5f, 0.3f, -0.2f), Quaternion.Euler(0, 0, 0), 4},
        {"Clone12", new Vector3(-1.2f, 0.3f, -0.2f), Quaternion.Euler(0, 0, 0), 2},
        {"Clone13", new Vector3(-0.9f, 0.6f, -0.2f), Quaternion.Euler(0, 0, 0), 6},
        {"Clone14", new Vector3(-1.3f, 0.6f, -0.1f), Quaternion.Euler(0, 0, 0), 7},
        {"Clone15", new Vector3(-1.3f, 0.6f, -0.3f), Quaternion.Euler(0, 0, 0), 7},
        {"Clone16", new Vector3(-1.5f, 0.6f, -0.1f), Quaternion.Euler(0, 0, 0), 7},
        {"Clone17", new Vector3(-1.5f, 0.6f, -0.3f), Quaternion.Euler(0, 0, 0), 7},
        {"Clone18", new Vector3(-1.3f, 0.6f, -0.2f), Quaternion.Euler(0, 0, 0), 6},
        {"Clone19", new Vector3(-0.9f, 0.6f, -0.1f), Quaternion.Euler(0, 0, 0), 8},
        {"Clone20", new Vector3(-0.9f, 0.6f, -0.3f), Quaternion.Euler(0, 0, 0), 8}
    };
    

    void Start()
    {
        bricksList = Resources.LoadAll("Ghosts", typeof(GameObject)).Cast<GameObject>().ToArray();
        Instantiate(bricksList[0], (Vector3)giraffeScheme[0, 1], Quaternion.identity);
    }
    
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
                        Instantiate(bricksList[1], (Vector3)giraffeScheme[count + 1, 1], Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(bricksList[0], (Vector3)giraffeScheme[count + 1, 1], Quaternion.identity);
                    }
                    count++;
                }
            }
        }
    }
}