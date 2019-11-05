using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

[Serializable]
[XmlType("Tobacco")]
public class Tobacco
{
    [XmlAttribute("Label")]
    public string Label { get; set; }
    [XmlAttribute("Strength")]
    public int Strength { get; set; }
    [XmlAttribute("Category")]
    public string Category { get; set;  }
    [XmlAttribute("Flavour")]
    public string Flavour { get; set; }

    public Tobacco() {}

    public Tobacco(string label, int strength, string category, string flavour)
    {
        Label = label;
        Strength = strength;
        Category = category;
        Flavour = flavour;
    }
    
    public string getFlavour()
    {
        return Flavour;
    }
    
    //Category: 
//    Миксы - Mixes
//    Свежие - Fresh
//    Напитки - Drinks
//    Пряные - Spicy
//    Сладости - Sweets
//    Фруктовые - Fruit
//    Цветочно-травяные - Floral-herbal
//    Цитрусовые - Citrus
//    Ягодные - Berry
//    Другие - Others

}
