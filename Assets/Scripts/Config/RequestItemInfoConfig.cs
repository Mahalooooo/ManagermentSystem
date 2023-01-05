using System;
using System.Collections;
using System.Collections.Generic;
using Robotlegs.Bender.Extensions.EventCommand.API;
using Robotlegs.Bender.Extensions.Mediation.API;
using Robotlegs.Bender.Framework.API;
using UnityEngine;

public class RequestItemInfoConfig : IConfig
{
	[Inject]
	public IMediatorMap mediatorMap;

	[Inject]
	public IEventCommandMap eventCommandMap;

	[Inject]
	public IInjector injector;

	[Inject]
	public IContext context;

	public void Configure()
	{
		//view绑定
		mediatorMap.Map<RequestItemInfoView>().ToMediator<RequestItemInfoMediator>();
		mediatorMap.Map<ConnectServerView>().ToMediator<ConnectServerMediator>();

		//event绑定
		eventCommandMap.Map(RequestItemInfoEvent.Type.View_To_Command).ToCommand<RequestItemInfoCommand>();

		//注入绑定
		injector.Map<IService>().ToSingleton<RequestItemInfoService>();

		context.AfterInitializing(StartApplication);
	}

	private void StartApplication()
	{
		GameObject obj = GameObject.FindGameObjectWithTag("grid");
		obj.AddComponent<RequestItemInfoView>();
	}
}
