using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPanel : MonoBehaviour
{
	//面板预制体
	private string panelPath = "Prefabs";
	private GameObject canvace
	{
		get
		{
			return GameObject.FindGameObjectWithTag("Canvace");
		}
	}
	public void LoadUIPanel(string panelName)
	{
		SelectionType type = (SelectionType)System.Enum.Parse(typeof(SelectionType), panelName);

		//加载面板
		InstantiatePanel(type);
	}


	private void InstantiatePanel(SelectionType type)
	{
		switch (type)
		{
			//加载参考面板
			case SelectionType.REFERENCE:
				GameObject obj = GameObject.Instantiate(Resources.Load<GameObject>(panelPath + "/Reference/ReferencePanel"));
				obj.transform.SetParent(this.canvace.transform, false);
				break;
			default:
				break;
		}
	}
}
