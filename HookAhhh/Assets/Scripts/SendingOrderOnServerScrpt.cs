using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

public class SendingOrderOnServerScrpt : MonoBehaviour
{
    public void SendingOrderOnServer(Order order)
    {
        print("click");
        var httpWebRequest = (HttpWebRequest) WebRequest.Create("https://hookahserver.herokuapp.com/order/add");
        httpWebRequest.ContentType = "";
        httpWebRequest.Method = "POST";
        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        {
            string json = JsonUtility.ToJson(order);

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
