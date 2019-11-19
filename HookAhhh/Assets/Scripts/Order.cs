using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Order
{
    [SerializeField]
    public List<Zabiv> order;

    [SerializeField]
    public int cost = 0;

    [SerializeField]
    public string guestName;

    [SerializeField]
    public string comments;
    
    public Order()
    {
        order = new List<Zabiv>();
    }

    public void addElementToOrder(Zabiv zabiv, string comments)
    {
        this.comments = comments;
        order.Add(zabiv);
        cost += 1200;
    }

    public void removeElementFromOrder(Zabiv zabiv)
    {
        order.Remove(zabiv);
    }

    public string getComments()
    {
        return comments;
    }

    public string getGuestName()
    {
        return guestName;
    }

    public void setGuestName(string guestName)
    {
        this.guestName = guestName;
    }

    public int getCost()
    {
        return cost;
    }

    public void setCost(int cost)
    {
        this.cost = cost;
    }

    public int getCountZabiv()
    {
        return order.Count;
    }

    public Zabiv getZabiv(int number)
    {
        return order[number];
    }
}