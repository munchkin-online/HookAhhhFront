using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tobacco : MonoBehaviour
{
    private string _label;
    private int _strength;
    private string _category;
    private string _flavor; 
    
    public Tobacco(string label, int strength, string category, string flavor)
    {
        _label = label;
        _strength = strength;
        _category = category;
        _flavor = flavor;
    }
    
    //Category: 
//    Миксы - Mixes
//    Мятные - Mint
//    Напитки - Drinks
//    Пряные - Spicy
//    Сладости - Sweets
//    Фруктовые - Fruit
//    Цветочно-травяные - Floral-herbal
//    Цитрусовые - Citrus
//    Ягодные - Berry

    public string getLabel()
    {
        return _label;
    }

    public void setLabel(string label)
    {
        _label = label;
    }
    
    public int getStrength()
    {
        return _strength;
    }

    public void setStrength(int strength)
    {
        _strength = strength;
    }
    
    public string getCategory()
    {
        return _category;
    }

    public void setCategory(string category)
    {
        _category = category;
    }
    
    public string getFlavor() 
    {
        return _flavor;
    }

    public void setFlavor(string flavor)
    {
        _flavor = flavor;
    }
}
