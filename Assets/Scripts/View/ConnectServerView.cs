using System.Collections;
using System.Collections.Generic;
using Robotlegs.Bender.Platforms.Unity.Extensions.Mediation.Impl;
using UnityEngine;

public class ConnectServerView : EventView
{
	protected override void Start()
	{
		base.Start();

		dispatcher.Dispatch(new RequestItemInfoEvent(RequestItemInfoEvent.Type.View_To_Command));
	}
}
