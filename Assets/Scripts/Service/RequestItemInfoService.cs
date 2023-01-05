using System;
using System.Collections;
using System.Collections.Generic;
using Robotlegs.Bender.Extensions.EventManagement.API;
using UnityEngine;

public class RequestItemInfoService : IService
{
	[Inject]
	public IEventDispatcher dispatcher { get; set; }

	public void OnRequest()
	{
	}

	public void OnReceive()
	{
	}

	public void Update(string url, int score)
	{
	}
}



