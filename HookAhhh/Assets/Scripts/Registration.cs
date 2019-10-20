using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class PersonReg
{
    public string username;
    public string password;
    public string role;
}

public class Registration : MonoBehaviour
{
    public InputField inputFieldEmail;
    public InputField inputFieldPassword;
    

    public void OnClick()
    {
        print("click");
        var httpWebRequest = (HttpWebRequest) WebRequest.Create("https://hookahserver.herokuapp.com/registry");
        httpWebRequest.ContentType = "";
        httpWebRequest.Method = "POST";
        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        {

            var person = new PersonReg
            {
                username = inputFieldEmail.text,
                password = inputFieldPassword.text,
                role = "guest"
            };

            string jsonn = JsonUtility.ToJson(person);

            streamWriter.Write(jsonn);
        }

        var httpResponse = (HttpWebResponse) httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            var result = streamReader.ReadToEnd();
            print(result);
        }
    }
}
