using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PersonForRequest
{
    public string username;
    public string password;
}



[Serializable]
public class RequestUser
{
    public string username;
    public string password;
    public string mail;
    public bool active;
    public string role;
}
[Serializable]
public class RequestAnswer
{
    public int status;
    public string message;
    public RequestUser user;
}



public class OpenGuest : MonoBehaviour
{
    
    public InputField inputFieldEmail;
    public InputField inputFieldPassword;
    

    public void OnClick()
    {
        var httpWebRequest = (HttpWebRequest) WebRequest.Create("https://hookahserver.herokuapp.com/user/login");
        httpWebRequest.ContentType = "";
        httpWebRequest.Method = "POST";
        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        {

            var person = new PersonForRequest
            {
                username = inputFieldEmail.text,
                password = inputFieldPassword.text
            };

            string json = JsonUtility.ToJson(person);

            streamWriter.Write(json);
        }
        
        var httpResponse = (HttpWebResponse) httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            var result = streamReader.ReadToEnd();
            
            var answer = new RequestAnswer();
            answer = JsonUtility.FromJson<RequestAnswer>(result);
            var user = new RequestUser();
            user = answer.user;
            print(result);

            ListOrderOnBasket.userName = user.username;

            switch(user.role)
            {
                case "new":
                    Application.LoadLevel("Guest");
                    break;
                case "guest":
                    Application.LoadLevel("Guest");
                    break;
                case "master":
                    Application.LoadLevel("ViewOrderWindow");
                    break;
                default:
                    print("ERROR");
                    break;
            }
        }
    }
}
