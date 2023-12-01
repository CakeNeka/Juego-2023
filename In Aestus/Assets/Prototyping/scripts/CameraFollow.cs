using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]


    private Transform target;


    // Placing the position change in Late Update prevents the camera
    // from trying to move before the player does.
    void Update()
    {
        
    }
}
