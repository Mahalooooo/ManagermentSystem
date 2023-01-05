using System.Collections;
using System.Collections.Generic;
using Robotlegs.Bender.Extensions.EventManagement.API;
using UnityEngine;


public interface IService
{
	//向服务器发送分数请求
	void OnRequest();

	//接收到服务器响应
	void OnReceive();

	//向服务器请求数据更新
	void Update(string url, int score);

	//定义一个局部派发器
	IEventDispatcher dispatcher { get; set; }
}
