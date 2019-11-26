using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewOrderWindow : MonoBehaviour
{
    public RectTransform panel;
    public InputField name;
    public Button blocked;
    public Button blocking;
    public Button orders;

    public void Start()
    {
        name.gameObject.SetActive(false);
        blocked.gameObject.SetActive(false);
        orders.interactable = false;
    }

    public void onClickOrders()
    {
        name.gameObject.SetActive(false);
        blocked.gameObject.SetActive(false);
        panel.gameObject.SetActive(true);
        orders.interactable = false;
        blocking.interactable = true;
    }
    
    public void onClickBlocking()
    {
        name.gameObject.SetActive(true);
        blocked.gameObject.SetActive(true);
        panel.gameObject.SetActive(false);
        orders.interactable = true;
        blocking.interactable = false;
    }
}
