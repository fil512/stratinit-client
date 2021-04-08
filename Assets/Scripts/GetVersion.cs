using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetVersion : MonoBehaviour
{
    public bool Running { get; private set; }

    public void Call()
    {
        Running = true;
        StartCoroutine(GetRequest("http://localhost:8081/stratinit/version", (result) =>
        {
            Debug.Log("RESULT: " + result);
            Running = false;
        }));
    }

   IEnumerator GetRequest(string url, Action<string> result)
    {
        string authorization = authenticate("test1", "testy");
        UnityWebRequest www = UnityWebRequest.Get(url);
        www.SetRequestHeader("Authorization", authorization);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
         Debug.Log(www.error);
         if (result != null)
             result(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.data); // this log is returning the requested data. 
            if (result != null)
                result(www.downloadHandler.text);
        }
    }
   
   string authenticate(string username, string password)
   {
       string auth = username + ":" + password;
       auth = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(auth));
       auth = "Basic " + auth;
       return auth;
   }
}