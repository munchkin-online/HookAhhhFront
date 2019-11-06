using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterGoToOrders : MonoBehaviour
{
    public Camera mainCamera;
    public Camera cameraBlocking;
    
    
    public void onClick()
    {
        mainCamera.enabled = true;
        cameraBlocking.enabled = false;
    }
}
