using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

[Serializable]
[XmlRoot("TabaccoState")]
[XmlInclude(typeof(Tobacco))]
public class TobaccoState
{
    [XmlArray("Tobaccos")]
    [XmlArrayItem("TobaccosItem")]
    public List<Tobacco> tobaccos = new List<Tobacco>();

    public TobaccoState()
    {
        
    }
    public void Add(Tobacco tobacco)
    {
        tobaccos.Add(tobacco);
    }

    public void Clear()
    {
        tobaccos.Clear();
    }
}
