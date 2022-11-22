using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class SendForm : MonoBehaviour
{
    void Start()
    {
         StartCoroutine(Upload());
    }

    IEnumerator Upload(){
        byte[] data = Encoding.ASCII.GetBytes("25");
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection("age", data));
        Debug.Log(formData);
        UnityWebRequest www = UnityWebRequest.Post("http://127.0.0.1:5000/", formData);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
        
    }
}
