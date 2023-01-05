using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using TMPro;
using Tool;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ItemPrefabl;
    public GameObject ItemContent;
    public Toggle allToggle;
    public TMP_InputField seach;
    public TMP_InputField sendmsg;
    public Button sendmsgbtn;
    private List<GameObject> ItemList = new List<GameObject>();
    private int total;
    private int page=1;



    public PageGrid pageGrid;
    void Start()
    {
        EventManager.AddListener(EventType.JumpPage, JumpEvent);
      //  ServicePointManager.ServerCertificateValidationCallback = HttpsCertificateValidationCallback;
         SendClintAsync(page.ToString());
        allToggle.isOn = false;
        allToggle.onValueChanged.AddListener((res) =>
        {
            if (res)
            {
                ItemList.ForEach(ietm =>
                {
                    ietm.GetComponent<ItemView>().toggle.isOn = true;
                });
            }
            else
            {
                ItemList.ForEach(ietm =>
                {
                    ietm.GetComponent<ItemView>().toggle.isOn = false;
                });

            }
        });

        seach.onValueChanged.AddListener(res =>
        {
            if (string.IsNullOrEmpty(res))
            {
                SendClintAsync(page.ToString());

            }
            else
            {
                SendClintAsync(1.ToString(),res);

            }
        });
        sendmsgbtn.onClick.AddListener(() =>
        {

            ItemList.ForEach(res =>
            {
                var item = res.GetComponent<ItemView>();
               if (item.toggle.isOn)
                {
                    Http.Instance.Get("app/im/pushMsg?userId=" + item.id, SendCallback);
                }
            });
        });
    }

    private void JumpEvent(object obj)
    {
        var page = obj.ToString();
        SendClintAsync(page, "");

    }

    private void SendCallback(string obj)
    {
        Debug.Log(obj);
    }

    public void SendClintAsync(string page, string name="")
    {
        var Url = string.Format("app/user/op/list?nickname={0}&pageNum={1}&pageSize=10",name,page);

        Http.Instance.Get(Url, Callback);



    }


    private void Callback(string res)
    {
        if (!string.IsNullOrEmpty(res))
        {
            var Data = LitJson.JsonMapper.ToObject<Root>(res);
            if (Data.code == 200)
            {
                if (Data.total > 10)
                {
                    if (Data.total % 10 == 0) {

                        var pages = Math.Floor((decimal)Data.total / 10);
                        pageGrid.maxPageIndex = (int)pages;

                    }
                    else
                    {
                        var pages = Math.Floor((decimal)Data.total / 10);
                        pageGrid.maxPageIndex = (int)pages+1;
                    }
                    
                  
                }
                else if(Data.total==10)
                {
                    pageGrid.maxPageIndex = 1;
                }
                pageGrid.UpadateUIPageFromHead();
                total = Data.total;
                allToggle.isOn = false;

                ItemList.ForEach(item =>
                {
                    DestroyImmediate(item);
                });
                ItemList.Clear();
                Data.rows.ForEach(rowsitem =>
                {
                    var item = Instantiate<GameObject>(ItemPrefabl, ItemContent.transform, false);
                    item.GetComponent<ItemView>().Init(rowsitem);
                    ItemList.Add(item);
                });
               

            }
        }
    }


}
public class RowsItem
{
    /// <summary>
    /// 
    /// </summary>
    public int id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int gender { get; set; }
    /// <summary>
    /// 李松阳啊
    /// </summary>
    public string nickname { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string mobile { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string avatar { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string signature { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string inviteCode { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int onlineStatus { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string lastLogoutTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string lastLoginTime { get; set; }
}

public class Root
{
    /// <summary>
    /// 
    /// </summary>
    public int total { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int pages { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List<RowsItem> rows { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int code { get; set; }
    /// <summary>
    /// 查询成功
    /// </summary>
    public string msg { get; set; }
}
