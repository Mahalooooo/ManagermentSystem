using System;
using System.Collections;
using System.Collections.Generic;
using Robotlegs.Bender.Extensions.CommandCenter.API;
using UnityEngine;

public class RequestItemInfoCommand : ICommand
{
	[Inject]
	public IService requestItemInfoService;

	public void Execute()
	{
		requestItemInfoService.dispatcher.AddEventListener<RequestItemInfoEvent>(RequestItemInfoEvent.Type.Command_To_Service, RequestItemInfoComplete);
		requestItemInfoService.OnRequest();
	}

	private void RequestItemInfoComplete(RequestItemInfoEvent evt)
	{
		requestItemInfoService.dispatcher.RemoveEventListener<RequestItemInfoEvent>(RequestItemInfoEvent.Type.Command_To_Service, RequestItemInfoComplete);
	}
}
