using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
public class PersonBlocked
{
    public string username;
    public string role;
}
public class Blocked : MonoBehaviour
{
    public InputField inputFieldName;
    
    


    public void OnClick()
    {
        var httpWebRequest = (HttpWebRequest) WebRequest.Create("https://hookahserver.herokuapp.com/user/status");
        httpWebRequest.ContentType = "";
        httpWebRequest.Method = "POST";
        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        {
            
            var person = new PersonBlocked
            {
                username = inputFieldName.text,
                role = "blocked"
            };

            string json = JsonUtility.ToJson(person);

            streamWriter.Write(json);
        }
        
        var httpResponse = (HttpWebResponse) httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            var result = streamReader.ReadToEnd();
            print(result);
            
        }
    }
}
