using System.Collections;
using System.Collections.Generic;
using Robotlegs.Bender.Bundles.MVCS;
using UnityEngine;

public class ConnectServerMediator : Mediator
{
	[Inject]
	public ConnectServerView connectServerView;

	public override void Initialize()
	{
		AddViewListener<ConnectServerEvent>(ConnectServerEvent.Type.ConnectServer, Dispatch);
	}
}
