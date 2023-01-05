using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public static class Ajax
{
    public static async void Request(string url, string method, Dictionary<string, string> headers, Dictionary<string, string> parameters, UnityAction<string> success,
        UnityAction<string> failed)
    {
        try
        {
            var request = new UnityWebRequest(url, method);
            request.downloadHandler = new DownloadHandlerBuffer();
            if (headers != null && headers.Count > 0)
            {
                foreach (var h in headers)
                {
                    request.SetRequestHeader(h.Key, h.Value);
                }
            }

            if (parameters != null && parameters.Count > 0)
            {
                string json = JsonConvert.SerializeObject(parameters);
                request.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));
                request.uploadHandler.contentType = "application/json";
            }

            await request.SendWebRequest();
#if UNITY_EDITOR
            Debug.Log($"【AJAX Request】:{request.url}:{request.downloadHandler.text}");
#endif
            if (string.IsNullOrEmpty(request.error))
            {
                Debug.Log($"Ajax [{request.url}]:Request Success Response:{request.downloadHandler.text}");
                success?.Invoke(request.downloadHandler.text);
            }
            else
            {
                Debug.LogError($"Ajax [{request.url}]:Request Failed Response:{request.error}");
                failed?.Invoke(request.error);
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Ajax:Request Exception:"+e.ToString());
            failed?.Invoke(e.ToString());
        }
    }
}
