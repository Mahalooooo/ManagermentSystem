using System.Collections;
using System.Collections.Generic;
using Robotlegs.Bender.Extensions.EventManagement.Impl;

public class ConnectServerEvent : Event
{

	public enum Type
	{
		ConnectServer
	}

	public ConnectServerEvent(ConnectServerEvent.Type type) : base(type)
	{

	}
}

