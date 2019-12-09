using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveOrderOnBasket : MonoBehaviour
{
    public RectTransform prefab;
    public void OnClick()
    {
        var i = prefab.gameObject.transform.Find("TextId").GetComponent<Text>().text;
        var go = GameObject.Find("Content");
        go.GetComponent<ScrollContentBasket>().RemoveOrder(int.Parse(i));
        print("delete zabiv");
    }
}
