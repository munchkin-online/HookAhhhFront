using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyHookah : MonoBehaviour
{
    List<Zabiv> EasyHookahZabivs = new List<Zabiv>();
    public List<Tobacco> TList;

    public void initList()
    {
        TList = Serializer.DeXml(Serializer.DataPathTobaccos).tobaccos;
    }

    public void CreateZabiv()
    {
        EasyHookahZabivs.Add(new Zabiv(TList[150]));
        EasyHookahZabivs.Add(new Zabiv(new Tobacco("Must Have", 7, "Fruit", "Pineapple"), new Tobacco("Sherbetli", 5, "Fruit", "Pineapple")));
        EasyHookahZabivs.Add(new Zabiv(new Tobacco("Sherbetli", 7, "Drinks", "Cola")));
        EasyHookahZabivs.Add(new Zabiv(new Tobacco("Adalia", 7, "Fruit", "Apple"), new Tobacco("Sherbetli", 5, "Fruit", "Pineapple"),
            new Tobacco("Afzal", 8, "Fruit", "Watermellon")));
        EasyHookahZabivs.Add(new Zabiv(new Tobacco("Darkside", 7, "Fruit", "Orange")));
        EasyHookahZabivs.Add(new Zabiv(new Tobacco("Darkside", 7, "Fruit", "Mellon")));
        EasyHookahZabivs.Add(new Zabiv(new Tobacco("Adalia", 5, "Fruit", "Strawberry"), new Tobacco("Sherbetli", 5, "Fruit", "Cherry")));
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
