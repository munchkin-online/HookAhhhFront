using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Zabiv : MonoBehaviour
{
    private Tobacco _flavour1 = new Tobacco();
    private Tobacco _flavour2 = new Tobacco();
    private Tobacco _flavour3 = new Tobacco();
    private int _numofflavours;

    public int getStrength()
    { 
        if (_numofflavours == 3)
            return (_flavour1.Strength + _flavour2.Strength + _flavour3.Strength) / 3;
        else if (_numofflavours == 2)
            return (_flavour1.Strength + _flavour2.Strength) / 2;
        else if (_numofflavours == 1)
            return _flavour1.Strength;
        else
            return 0;
    }
}
