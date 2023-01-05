using System.Collections;
using System.Collections.Generic;
using Robotlegs.Bender.Extensions.EventManagement.Impl;

public class RequestItemInfoEvent : Event
{
	public enum Type
	{
		View_To_Command,
		Command_To_Service,
	}

	public RequestItemInfoEvent(RequestItemInfoEvent.Type type) : base(type)
	{

	}
}
