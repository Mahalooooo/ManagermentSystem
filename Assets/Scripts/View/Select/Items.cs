using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
	public List<GameObject> items = new List<GameObject>();

	//缩放时间
	public float time = 1.3f;

	//原先大小
	public Vector2 oldSize;

	//放大缩小速度
	public float speed;

	private void Start()
	{
		for (int i = 0; i < items.Count; i++)
		{
			SelectionTriggerListener.GetComponent<SelectionTriggerListener>(items[i]).onEnter = OnMouseEnter;
			SelectionTriggerListener.GetComponent<SelectionTriggerListener>(items[i]).onExit = OnMouseExit;
		}
	}


	void OnMouseEnter(GameObject go)
	{
		SelectionTriggerListener.GetComponent<SelectionTriggerListener>(go).UpdateSize(oldSize * time, speed);
	}

	void OnMouseExit(GameObject go)
	{
		SelectionTriggerListener.GetComponent<SelectionTriggerListener>(go).UpdateSize(oldSize, speed);
	}
}
