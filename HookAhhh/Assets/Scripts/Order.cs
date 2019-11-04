using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    private int _cost = 0;
    ArrayList order = new ArrayList();

    public void addElementToOrder(Zabiv zabiv)
    {
        order.Add(zabiv);
        _cost += 1200;
    }

    public void removeElementFromOrder(int id)
    {
        order.Remove(id);
    }

    public int getCost()
    {
        return _cost;
    }

    public void setCost(int cost)
    {
        _cost = cost;
    }
}