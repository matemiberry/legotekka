using System.Linq;
using UnityEngine;

public class LegoCrocodileBuilder : MonoBehaviour
{
    public GameObject[] bricksList;
    public static int count;
    public AudioSource correctSound;

    private readonly object[,] _scheme = new object[21, 4]
    {
        // { CloneName, Position, Rotation, GhostBrickName }
        {"Clone0", new Vector3(-0.2f, 0.0f, -0.2f), Quaternion.Euler(0, 0, 0), 3},
        {"Clone1", new Vector3(-0.5f, 0.08f, -0.2f), Quaternion.Euler(0, 0, 0), 4},
        {"Clone2", new Vector3(0.1f, 0.08f, -0.2f), Quaternion.Euler(0, 0, 0), 4},
        {"Clone3", new Vector3(0.6f, 0.08f, -0.2f), Quaternion.Euler(0, 90, 0), 2},
        {"Clone4", new Vector3(-1.0f, 0.08f, -0.2f), Quaternion.Euler(0, 90, 0), 2},
        {"Clone5", new Vector3(0.0f, 0.32f, -0.2f), Quaternion.Euler(0, -180, 0), 5},
        {"Clone6", new Vector3(0.4f, 0.32f, -0.2f), Quaternion.Euler(0, 0, 0), 5},
        {"Clone7", new Vector3(1.1f, 0.0f, -0.2f), Quaternion.Euler(0, 0, 0), 6},
        {"Clone8", new Vector3(1.2f, 0.08f, -0.2f), Quaternion.Euler(0, 0, 0), 2},
        {"Clone9", new Vector3(0.8f, 0.32f, -0.2f), Quaternion.Euler(0, 180, 0), 5},
        {"Clone10", new Vector3(1.2f, 0.32f, -0.2f), Quaternion.Euler(0, 0, 0), 5},
        {"Clone11", new Vector3(-0.5f, 0.32f, -0.2f), Quaternion.Euler(0, 0, 0), 4},
        {"Clone12", new Vector3(-1.2f, 0.32f, -0.2f), Quaternion.Euler(0, 0, 0), 2},
        {"Clone13", new Vector3(-0.9f, 0.56f, -0.2f), Quaternion.Euler(0, 0, 0), 6},
        {"Clone14", new Vector3(-1.3f, 0.56f, -0.1f), Quaternion.Euler(0, 0, 0), 7},
        {"Clone15", new Vector3(-1.3f, 0.56f, -0.3f), Quaternion.Euler(0, 0, 0), 7},
        {"Clone16", new Vector3(-1.5f, 0.56f, -0.1f), Quaternion.Euler(0, 0, 0), 7},
        {"Clone17", new Vector3(-1.5f, 0.56f, -0.3f), Quaternion.Euler(0, 0, 0), 7},
        {"Clone18", new Vector3(-1.3f, 0.64f, -0.2f), Quaternion.Euler(0, 0, 0), 6},
        {"Clone19", new Vector3(-0.9f, 0.64f, -0.1f), Quaternion.Euler(0, 0, 0), 8},
        {"Clone20", new Vector3(-0.9f, 0.64f, -0.3f), Quaternion.Euler(0, 0, 0), 8}
    };


    private void Start()
    {
        bricksList = Resources.LoadAll("Ghosts", typeof(GameObject)).Cast<GameObject>().ToArray();
        Instantiate(bricksList[(int) _scheme[count, 3]], (Vector3) _scheme[0, 1], (Quaternion) _scheme[0, 2]);
    }

    private void Update()
    {
        if (GameObject.Find((string) _scheme[count, 0]) != null)
            if (GameObject.Find((string) _scheme[count, 0]).transform.position == (Vector3) _scheme[count, 1] &&
                Input.GetMouseButtonUp(0))
                if (count != _scheme.Length)
                {
                    
                    Instantiate(bricksList[(int) _scheme[count + 1, 3]], (Vector3) _scheme[count + 1, 1],
                        (Quaternion) _scheme[count + 1, 2]);
                    correctSound.Play();
                    count++;
                }
    }
}