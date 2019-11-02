

using System;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class Serializer
{
   public static readonly string FileName = "tobaccos";
   public static readonly string DataPathTobaccos = Application.dataPath + "/tobaccos" + ".xml";
   public static void SaveXml(TobaccoState state, string fileName)
   {
      switch(fileName)
      {
         case "tobaccos":
            Type[] extraTypes= { typeof(Tobacco)};
            XmlSerializer serializer = new XmlSerializer(typeof(TobaccoState), extraTypes); 

            FileStream fs = new FileStream(DataPathTobaccos, FileMode.Create); 
            serializer.Serialize(fs, state); 
            fs.Close();
            break;
            
      }  
   }

   public static TobaccoState DeXml(string dataPath)
   {
      Type[] extraTypes = {typeof(Tobacco)};
      XmlSerializer serializer = new XmlSerializer(typeof(TobaccoState), extraTypes);
      
      FileStream fs = new FileStream(dataPath, FileMode.Open);
      TobaccoState state = (TobaccoState) serializer.Deserialize(fs);
      fs.Close();
      return state;
   }
}
