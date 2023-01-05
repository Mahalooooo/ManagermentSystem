using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class  Http : MonoBehaviour
{

    public static Http Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update

    public  void Get(string url,Action<string> Callback)
    {
        StartCoroutine(HttpTool.Instance.HttpGet(url, Callback));
    }
 
    public void Post(string url,string data, Action<string> Callback)
    {
        StartCoroutine(HttpTool.Instance.HttpPost(url, data, Callback));
    }
    public void Delete(string url,string data, Action<string> Callback)
    {
        StartCoroutine(HttpTool.Instance.HttpDelete(url, data, Callback));
    }
    public void GetTexture(string Url,Action<Texture>caalback)
    {
        StartCoroutine(HttpTool.Instance.DownSprite(Url, caalback)); 
       
    }

    ////
    ///º”‘ÿ≥°æ∞
    ///


}
