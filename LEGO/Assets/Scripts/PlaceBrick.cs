﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceBrick : MonoBehaviour
{
    public static Brick[] BrickLib;
    public static Material[] MatLib;
    protected Brick PrefabBrick;
    public Material TransparentMat;
    protected Material BrickMat;
    public static int counter;
    protected Controller Controller;
    public static Brick CurrentBrick;
    protected bool PositionOk;

    protected ModeChange ModeChange;

    public static int MouseInput0 = 0;
    public static int MouseInput1 = 1;
    public Button curButton;



    void Awake()
    {
        Controller = GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (BrickLib != null && MatLib != null)
        {
            PrefabBrick = BrickLib[0];
            BrickMat = MatLib[0];
        }
        
        if (Controller.Mode != Controller.ControllerMode.Build)
        {
            if (CurrentBrick != null)
                Destroy(CurrentBrick.gameObject);
            return;
        }
        else
        {
            if (CurrentBrick == null)
                SetNextBrick();
        }

        if (CurrentBrick != null)
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hitInfo))
            {

                // Snap to grid
                var position = LegoLogic.SnapToGrid(hitInfo.point);

                // Try to find a collision free position
                var placePosition = position;

                var rotation = CurrentBrick.transform.rotation;
                switch (CurrentBrick.name)
                {
                    // Костыль для детали 1х2
                    case "0(Clone)" when (rotation.y is 0 || Math.Abs(rotation.y) is 1):
                        placePosition.z = placePosition.z + 0.1f;
                        break;
                    case "0(Clone)":
                        placePosition.x = placePosition.x + 0.1f;
                        break;
                    // Crutch for Stud
                    case "9(Clone)":
                        placePosition.z = placePosition.z + 0.1f;
                        placePosition.x = placePosition.x + 0.1f;
                        break;
                }

                // Crutch for 2x6 Plate
                if ((CurrentBrick.name == "8(Clone)" || CurrentBrick.name == "6(Clone)") &&
                    (CurrentBrick.transform.rotation.y is 0 || Math.Abs(CurrentBrick.transform.rotation.y) is 1))
                {
                    placePosition.x = placePosition.x + 0.1f;
                }
                else if (CurrentBrick.name == "8(Clone)" || CurrentBrick.name == "6(Clone)")
                {
                    placePosition.z = placePosition.z + 0.1f;
                }

                PositionOk = false;
                for (int i = 0; i < 10; i++)
                {
                    var collider = Physics.OverlapBox(placePosition + CurrentBrick.transform.rotation * CurrentBrick.Collider.center, 
                        CurrentBrick.Collider.size / 2, CurrentBrick.transform.rotation, LegoLogic.LayerMaskLego);
                    PositionOk = collider.Length == 0;
                    if (PositionOk)
                        break;
                    else
                        placePosition.y += LegoLogic.Grid.y;
                }

                CurrentBrick.transform.position = PositionOk ? placePosition : position;
            }
        }
        
        

        // Place Brick
        if (Input.GetMouseButtonUp(MouseInput0) && CurrentBrick != null && PositionOk)
        {
            CurrentBrick.Collider.enabled = true;
            CurrentBrick.name = "Clone" + counter;
            counter++;
            CurrentBrick.SetMaterial(BrickMat);
            // var rot = CurrentBrick.transform.rotation;
            CurrentBrick = null;
            SetNextBrick();
            // CurrentBrick.transform.rotation = rot;
            Controller.Mode = Controller.ControllerMode.Play;
        }

        // Rotate Brick
        if (Input.GetKeyDown(KeyCode.E))
            CurrentBrick.transform.Rotate(Vector3.up, 90);

        // Delete Brick
        if (Input.GetMouseButtonDown(MouseInput1))
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitInfo))
            {
                var brick = hitInfo.collider.GetComponent<Brick>();
                if (brick != null)
                {
                    GameObject.DestroyImmediate(brick.gameObject);
                    PlaceBrick.MouseInput0 = 0;
                    PlaceBrick.MouseInput1 = 1;
                    Click4x2.count--;
                    curButton.GetComponent<Image>().sprite = Click4x2.sprites[Click4x2.count];
                    Controller.Mode = Controller.ControllerMode.Play;
                    ClickDelete.active = false;
                    counter--;
                }
        
            }
            

        }

    }

    public void SetNextBrick()
    {
        CurrentBrick = Instantiate(PrefabBrick);
        CurrentBrick.Collider.enabled = false;
        CurrentBrick.SetMaterial(TransparentMat);
    }

    public void SetPrefab(int brick, int mat)
    {
        PrefabBrick = BrickLib[brick];
        BrickMat = MatLib[mat];
    }
}
