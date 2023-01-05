using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    // Start is called before the first frame update

    public Toggle toggle;
    public RawImage head;
    public TMP_Text name;
    public TMP_Text phone;
    public TMP_Text signature;
    public TMP_Text inviteCode;
    public TMP_Text onlineStatus;
    public TMP_Text lastLogoutTime;
    public TMP_Text lastLoginTime;


    public string id;
    void Start()
    {
        
    }

    public void Init(RowsItem rowsItem)
    {
        id = rowsItem.id.ToString();
        Http.Instance.GetTexture(rowsItem.avatar, ((res) =>
        {
            head.texture = res;
        }));
        name.text = rowsItem.nickname;
        phone.text = rowsItem.mobile;
        signature.text = rowsItem.signature;
        inviteCode.text = rowsItem.inviteCode;
        if (rowsItem.onlineStatus == 1)
        {
            onlineStatus.text = "‘⁄œﬂ";
        }
        else
        {
            onlineStatus.text = "¿Îœﬂ";
            onlineStatus.color = Color.gray;
        }
        lastLoginTime.text = rowsItem.lastLoginTime;
        lastLogoutTime.text = rowsItem.lastLogoutTime;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
