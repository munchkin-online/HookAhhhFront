using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyHookah : MonoBehaviour
{
    //ArrayList EasyHookahZabivs = new ArrayList();
    List<Zabiv> EasyHookahZabivs = new List<Zabiv>();
    public List<Tobacco> TList;

    public void initList()
    {
        TList = Serializer.DeXml(Serializer.DataPathTobaccos).tobaccos;
    }

    public Tobacco getItem(int id)
    {
        int i = 0;
        while (id != TList[i].getId())
        {
            i++;
        }

        return TList[i];
    }

    public void CreateZabiv()
    {
        EasyHookahZabivs.Add(new Zabiv(getItem(15), getItem(167), getItem(168)));
        EasyHookahZabivs.Add(new Zabiv(getItem(226), getItem(236), getItem(267)));
        EasyHookahZabivs.Add(new Zabiv(getItem(199), getItem(13)));
        EasyHookahZabivs.Add(new Zabiv(getItem(165), getItem(107), getItem(176)));
        EasyHookahZabivs.Add(new Zabiv(getItem(19), getItem(26)));
        EasyHookahZabivs.Add(new Zabiv(getItem(214), getItem(9)));
        EasyHookahZabivs.Add(new Zabiv(getItem(13), getItem(234)));
        EasyHookahZabivs.Add(new Zabiv(getItem(68), getItem(34)));
        EasyHookahZabivs.Add(new Zabiv(getItem(252), getItem(267)));
        EasyHookahZabivs.Add(new Zabiv(getItem(278), getItem(166), getItem(163)));
        EasyHookahZabivs.Add(new Zabiv(getItem(107), getItem(19)));
        EasyHookahZabivs.Add(new Zabiv(getItem(222), getItem(248)));
        EasyHookahZabivs.Add(new Zabiv(getItem(35), getItem(7), getItem(37)));
        EasyHookahZabivs.Add(new Zabiv(getItem(200), getItem(203)));
        EasyHookahZabivs.Add(new Zabiv(getItem(77), getItem(199), getItem(170)));
        EasyHookahZabivs.Add(new Zabiv(getItem(236), getItem(109)));
        EasyHookahZabivs.Add(new Zabiv(getItem(66), getItem(30), getItem(94)));
        EasyHookahZabivs.Add(new Zabiv(getItem(233), getItem(237), getItem(256)));
    }

    public int getSize()
    {
        return EasyHookahZabivs.Count;
    }

    public Zabiv getElement(int i)
    { 
       Zabiv z = EasyHookahZabivs[i];
       return z;
    }

}
