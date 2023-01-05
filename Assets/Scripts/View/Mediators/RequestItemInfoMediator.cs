using System.Collections;
using System.Collections.Generic;
using Robotlegs.Bender.Bundles.MVCS;
using UnityEngine;

public class RequestItemInfoMediator : Mediator
{
	[Inject]
	public RequestItemInfoView requestItemInfoView;

	public override void Initialize()
	{
		AddViewListener<RequestItemInfoEvent>(RequestItemInfoEvent.Type.View_To_Command, Dispatch);
	}
}
