using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;


public class CreateTobaccoListAfterInit1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.InitTobaccoList();
    }

    private void InitTobaccoList()
    {
        var httpWebRequest = (HttpWebRequest) WebRequest.Create("https://hookahserver.herokuapp.com/tobacco/list");
        httpWebRequest.ContentType = "";
        httpWebRequest.Method = "POST";
        var httpResponse = (HttpWebResponse) httpWebRequest.GetResponse();
        using(var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            var result = streamReader.ReadToEnd();
            result = "{\"tobaccos\":" + result + "}";
            print(result);
            var answer = Wrapper.CreateFromJSON(result).tobaccos;
            /*foreach(var variable in answer)
            {
                print(variable.Id);
                print(variable.label);
                print(variable.strength);
                print(variable.category);
                print(variable.flavour);
            }*/
            var state = new TobaccoState {tobaccos = answer};
            Serializer.SaveXml(state, Serializer.FileName);
        }
    }
    
}
[System.Serializable]
public class Wrapper
{
    [SerializeField]
    public List<Tobacco> tobaccos;

    public static Wrapper CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<Wrapper>(jsonString);
    }

    public Wrapper()
    {
        tobaccos = new List<Tobacco>();
    }
}
