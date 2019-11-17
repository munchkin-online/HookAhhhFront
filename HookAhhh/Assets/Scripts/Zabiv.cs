using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


[Serializable]
public class Zabiv
{
    [SerializeField] 
    public List<Tobacco> flavours;
    
    [SerializeField] 
    public string name;

    public Zabiv()
    {
        flavours = new List<Tobacco>();
    }

    public Zabiv(Tobacco flavour1)
    {
        flavours = new List<Tobacco>();
        flavours.Add(flavour1);
        name = flavour1.flavour;
    }

    public Zabiv(Tobacco flavour1, Tobacco flavour2)
    {
        flavours = new List<Tobacco>();
        flavours.Add(flavour1);
        flavours.Add(flavour2);
        name = flavour1.flavour + "/" + flavour2.flavour;
    }
    
    public Zabiv(Tobacco flavour1, Tobacco flavour2, Tobacco flavour3)
    {
        flavours = new List<Tobacco>();
        flavours.Add(flavour1);
        flavours.Add(flavour2);
        flavours.Add(flavour3);
        name = flavour1.flavour + "/" + flavour2.flavour + "/" + flavour3.flavour;
    }
    
    public void addElementToZabiv(Tobacco tobacco)
    {
        if (flavours.Count < 3)
        {
            flavours.Add(tobacco);
        }
    }
    
    
    public int getStrength()
    { 
        if (flavours.Count == 3)
            return (flavours[0].strength + flavours[1].strength + flavours[2].strength) / 3;
        else if (flavours.Count == 2)
            return (flavours[0].strength + flavours[1].strength) / 2;
        else if (flavours.Count == 1)
            return flavours[0].strength;
        else
            return 0;
    }
    
    public string getName()
    {
        return name;
    }

    public int getCountZabiv()
    {
        return flavours.Count;
    }

    public Tobacco getFlavour1()
    {
        if (flavours.Count >= 1)
        {
            return flavours[0];
        }
        else
        {
            return null;
        }
    }
    
    public Tobacco getFlavour2()
    {
        if (flavours.Count >= 2)
        {
            return flavours[1];
        }
        else
        {
            return null;
        }
    }
    
    public Tobacco getFlavour3()
    {
        if (flavours.Count >= 3)
        {
            return flavours[2];
        }
        else
        {
            return null;
        }
    }
}






//Старый класс
/*[Serializable]
public class Zabiv : MonoBehaviour
{
    [SerializeField] 
    private Tobacco flavour1 = new Tobacco();
    [SerializeField] 
    private Tobacco flavour2 = new Tobacco();
    [SerializeField] 
    private Tobacco flavour3 = new Tobacco();
    [SerializeField] 
    private int numofflavours;
    [SerializeField] 
    private string name;

    public int getStrength()
    { 
        if (numofflavours == 3)
            return (flavour1.strength + flavour2.strength + flavour3.strength) / 3;
        else if (numofflavours == 2)
            return (flavour1.strength + flavour2.strength) / 2;
        else if (numofflavours == 1)
            return flavour1.strength;
        else
            return 0;
    }
    
    public Zabiv()
    {}

    public Zabiv(Tobacco flavour1)
    {
        this.flavour1 = flavour1;
        name = flavour1.flavour;
        numofflavours = 1;
    }
    
    public Zabiv(Tobacco flavour1, Tobacco flavour2)
    {
        this.flavour1 = flavour1;
        this.flavour2 = flavour2;
        name = flavour1.flavour + "/" + flavour2.flavour;
        numofflavours = 2;
    }
    
    public Zabiv(Tobacco flavour1, Tobacco flavour2, Tobacco flavour3)
    {
        this.flavour1 = flavour1;
        this.flavour2 = flavour2;
        this.flavour3 = flavour3;
        name = flavour1.flavour + "/" + flavour2.flavour + "/" + flavour3.flavour;
        numofflavours = 3;
    }

    public string getName()
    {
        return name;
    }

    public Tobacco getFlavour1()
    {
        return flavour1;
    }
    
    public Tobacco getFlavour2()
    {
        return flavour2;
    }
    
    public Tobacco getFlavour3()
    {
        return flavour3;
    }*/

