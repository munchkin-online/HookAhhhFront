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
    [XmlAttribute("Flavor")]
    public string Flavor { get; set; }

    public Tobacco() {}

    public Tobacco(string label, int strength, string category, string flavor)
    {
        Label = label;
        Strength = strength;
        Category = category;
        Flavor = flavor;
    }
    
    public string getFlavor()
    {
        return Flavor;
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

}
