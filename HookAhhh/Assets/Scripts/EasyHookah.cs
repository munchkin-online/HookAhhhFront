using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyHookah : MonoBehaviour
{
    //ArrayList EasyHookahZabivs = new ArrayList();
    List<Zabiv> EasyHookahZabivs = new List<Zabiv>();

    public void CreateZabiv()
    {
        EasyHookahZabivs.Add(new Zabiv(new Tobacco("Darkside", 7, "Fruit", "Mango")));
        EasyHookahZabivs.Add(new Zabiv(new Tobacco("Must Have", 7, "Fruit", "Pineapple")));
        EasyHookahZabivs.Add(new Zabiv(new Tobacco("Sherbetli", 7, "Drinks", "Cola")));
        EasyHookahZabivs.Add(new Zabiv(new Tobacco("Adalia", 7, "Fruit", "Apple")));
        EasyHookahZabivs.Add(new Zabiv(new Tobacco("Darkside", 7, "Fruit", "Orange")));
    }

    public int getSize()
    {
        return EasyHookahZabivs.Count;
    }

    public Zabiv getElement(int i)
    { ;
       Zabiv z = EasyHookahZabivs[i];
       return z;

    }

}
