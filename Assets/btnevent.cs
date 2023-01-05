using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class btnevent : MonoBehaviour
{
    // Start is called before the first frame update
    public string txt;
    public PageGrid PageGrid;
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(() =>
        {
            PageGrid.JumpPage(txt);
        });
    }
    public void SetPage(string str)
    {
        txt = str;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
