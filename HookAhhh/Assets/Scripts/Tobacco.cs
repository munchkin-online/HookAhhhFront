using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
[XmlType("Tobacco")]
public class Tobacco
{
    [SerializeField] 
    [XmlAttribute("Id")]
    public int Id;
    
    [SerializeField] 
    [XmlAttribute("label")]
    public string label;

    [SerializeField] 
    [XmlAttribute("strength")]
    public int strength;

    [SerializeField] 
    [XmlAttribute("category")]
    public string category;
    
    [SerializeField] 
    [XmlAttribute("flavour")]
    public string flavour;

    public Tobacco() {}

    public Tobacco(string label, int strength, string category, string flavour)
    {
        this.label = label;
        this.strength = strength;
        this.category = category;
        this.flavour = flavour;
    }
    
    public string getFlavour()
    {
        return flavour;
    }

    public int getStrength()
    {
        return strength;
    }

    public int getId()
    {
        return Id;
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
