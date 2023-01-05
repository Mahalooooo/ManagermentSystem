using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class HttpTool:MonoBehaviour
{
    private static HttpTool instence;
    public static HttpTool Instance
    {
        get
        {
            if (instence == null)
            {
                instence = new HttpTool(); 
            }
            return instence;
        }
    }

    public void Star()
    {
        
    }




    public IEnumerator HttpGet(string url,Action<string> CallBack)
    {
        UnityWebRequest request = new UnityWebRequest();



        request = UnityWebRequest.Get(HttpInfo.Url + url);

        //设置头文件 及 token值
       // request.SetRequestHeader("BoxAuthorization", Tool.CommonTool.Instance.GetToken());
        request.timeout = 60000;
        request.method = "Get";
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.ProtocolError || request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.LogError(request.error);
        }
        else
        {
            string result = request.downloadHandler.text;
            Debug.Log(result);
            if (CallBack != null)
            {
                CallBack(result);
            }
        }



    }

    public IEnumerator HttpPost(string url, string sendData=null, Action<string>Callback=null)
    {
       
        byte[] bytes = Encoding.UTF8.GetBytes(sendData);
        UnityWebRequest request = new UnityWebRequest(HttpInfo.Url + url, UnityWebRequest.kHttpVerbPOST)
        {
           
            uploadHandler = new UploadHandlerRaw(bytes),
            downloadHandler = new DownloadHandlerBuffer()
        };
        //request.SetRequestHeader("BoxAuthorization",Tool.CommonTool.Instance.GetToken());
        request.timeout = 60000;
        request.method = "Post";
        request.certificateHandler = new CertHandler();
        request.SetRequestHeader("Content-Type", "application/json;charset=utf-8");
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.ProtocolError || request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.LogError(request.error);

        }
        else
        {
            string result = request.downloadHandler.text;
            Debug.Log(result);
            if (Callback != null)
            {
                Callback(result);
            }
        }


    }
    public IEnumerator HttpDelete(string url, string sendData = null, Action<string> Callback = null)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(sendData);
        UnityWebRequest request = new UnityWebRequest(HttpInfo.Url + url, UnityWebRequest.kHttpVerbDELETE)
        {
            uploadHandler = new UploadHandlerRaw(bytes),
            downloadHandler = new DownloadHandlerBuffer()
        };
       // request.SetRequestHeader("BoxAuthorization", Tool.CommonTool.Instance.GetToken());
        request.timeout = 60000;
        request.method = "Delete";
        request.certificateHandler = new CertHandler();
        request.SetRequestHeader("Content-Type", "application/json;charset=utf-8");
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.ProtocolError || request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.LogError(request.error);

        }
        else
        {
            string result = request.downloadHandler.text;
            Debug.Log(result);
            if (Callback != null)
            {
                Callback(result);
            }
        }


    }

  


    public  IEnumerator  DownSprite(string url,Action<Texture>CallBack=null)
    {
        using (UnityWebRequest request = new UnityWebRequest(url))
        {
            DownloadHandlerTexture texDl = new DownloadHandlerTexture(true);
            request.downloadHandler = texDl;

            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ProtocolError || request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.LogError(request.error);
            }
            else
            {
                if (CallBack != null)
                {
                    CallBack(texDl.texture);
                }
            }
        }
    }

}



public class CertHandler : CertificateHandler
{
    protected override bool ValidateCertificate(byte[] certificateData)
    {
        return true;
    }
}
