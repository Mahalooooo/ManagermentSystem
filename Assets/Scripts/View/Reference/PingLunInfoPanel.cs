using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PingLunInfoPanel : MonoBehaviour,IPointerDownHandler
{
	public void OnPointerDown(PointerEventData eventData)
	{
		//鼠标按下
		Destroy(this.gameObject);
	}


	/// <summary>
	/// 提交按钮事件
	/// </summary>
	public void OnBtnSubmit()
	{
		//获取输入框输入信息
		InputField input = this.GetComponentInChildren<InputField>();

		Debug.Log("已提交！提交数据为：" + input.text);

		Destroy(this.gameObject);
	}
}
