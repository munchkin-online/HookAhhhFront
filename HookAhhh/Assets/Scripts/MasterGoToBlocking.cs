using System.Collections;
using System.Collections.Generic;
using System.Windows;
using UnityEngine;
using UnityEngine.UI;

public class MasterGoToBlocking : MonoBehaviour
{
    public Camera mainCamera;
    public Camera cameraBlocking;
    
    
    public void onClick()
    {
        mainCamera.enabled = false;
        cameraBlocking.enabled = true;
    }
    
}
