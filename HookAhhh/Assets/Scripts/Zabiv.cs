using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Zabiv : MonoBehaviour
{
    private string _name;
    private Tobacco _flavour1 = new Tobacco();
    private Tobacco _flavour2 = new Tobacco();
    private Tobacco _flavour3 = new Tobacco();
    private int _numofflavours;

    public int getStrength()
    { 
        if (_numofflavours == 3)
            return (_flavour1.getStrength() + _flavour2.getStrength() + _flavour3.getStrength()) / 3;
        else if (_numofflavours == 2)
            return (_flavour1.getStrength() + _flavour2.getStrength()) / 2;
        else if (_numofflavours == 1)
            return _flavour1.getStrength();
        else
            return 0;
    }
    
    
    public Zabiv()
    {}

    public Zabiv(Tobacco flavour1)
    {
        _flavour1 = flavour1;
        _name = flavour1.getFlavor();
    }
    
    public Zabiv(Tobacco flavour1, Tobacco flavour2)
    {
        _flavour1 = flavour1;
        _flavour2 = flavour2;
        _name = flavour1.getFlavor() + "/" + flavour2.getFlavor();
    }
    
    public Zabiv(Tobacco flavour1, Tobacco flavour2, Tobacco flavour3)
    {
        _flavour1 = flavour1;
        _flavour2 = flavour2;
        _flavour3 = flavour3;
        _name = flavour1.getFlavor() + "/" + flavour2.getFlavor() + "/" + flavour3.getFlavor();
    }

    public string getName()
    {
        return _name;
    }
    
}
