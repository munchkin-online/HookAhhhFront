using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    private int cost = 0;
    private string guestName;
    private string comments;
    ArrayList order = new ArrayList();

    public void addElementToOrder(Zabiv zabiv, string comments)
    {
        this.comments = comments;
        order.Add(zabiv);
        cost += 1200;
    }

    public void removeElementFromOrder(int id)
    {
        order.Remove(id);
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
}