using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReferencePanel : MonoBehaviour
{
	private GameObject girdObj;
	private RectTransform girdRectTransform;
	private ScrollRect scrollRect;
	private RectTransform scrollTransform;

	private void Start()
	{
		girdObj = GameObject.FindGameObjectWithTag("grid");
		girdRectTransform = girdObj.GetComponent<RectTransform>();
		scrollRect = GameObject.FindGameObjectWithTag("scroll").GetComponent<ScrollRect>();
		scrollTransform = GameObject.FindGameObjectWithTag("scroll").GetComponent<RectTransform>();
	}

	public void OnBtnOpenPanel(string panelType)
	{
		 ReferenceChildPanelType type = (ReferenceChildPanelType)System.Enum.Parse(typeof(ReferenceChildPanelType), panelType);

		switch (type)
		{
			case ReferenceChildPanelType.Pinglun_Info_Panel:
				OnBtnOpenPinYuPanel();
				break;
			case ReferenceChildPanelType.Xiangxi_Info_Panel:
				OnBtnOpenXiangXiXinXiPanel();
				break;
			default:
				break;
		}
	}

	/// <summary>
	/// 打开评语面板
	/// </summary>
	public void OnBtnOpenPinYuPanel()
	{
		GameObject obj = Resources.Load<GameObject>("Prefabs/Reference/pinglun_info_Panel");
		obj = GameObject.Instantiate(obj);
		obj.transform.SetParent(GameObject.FindGameObjectWithTag("right").transform, false);
		obj.transform.SetAsLastSibling();
	}

	/// <summary>
	/// 打开详细信息面板
	/// </summary>
	public void OnBtnOpenXiangXiXinXiPanel()
	{
		GameObject obj = Resources.Load<GameObject>("Prefabs/Reference/xiangxi_info_Panel");
		obj = GameObject.Instantiate(obj);
		obj.transform.SetParent(GameObject.FindGameObjectWithTag("right").transform, false);
		obj.transform.SetAsLastSibling();
	}

	/// <summary>
	/// 打开应用面板
	/// </summary>
	public void OnBtnOpenYingYongPanel()
	{
		//实例化DesignTask面板
		GameObject obj = Resources.Load<GameObject>("Prefabs/Reference/DesignTask/DesignTaskPanel");
		obj = GameObject.Instantiate(obj);
		obj.transform.SetParent(GameObject.FindGameObjectWithTag("Canvace").transform, false);
		obj.transform.SetAsLastSibling();

		//销毁自身
		Destroy(this.gameObject);
	}

	/// <summary>
	/// 关闭Reference面板
	/// </summary>
	public void OnBtnClose()
	{
		Destroy(this.gameObject);
	}


	/// <summary>
	/// 打开左边按钮
	/// </summary>
	public void OnBtnLeft()
	{
		if (girdObj.transform.localPosition.x <= -(girdRectTransform.sizeDelta.x - scrollTransform.sizeDelta.x) / 2)
		{
			girdObj.transform.localPosition = new Vector3(-(girdRectTransform.sizeDelta.x - scrollTransform.sizeDelta.x) / 2, 0, 0);
			return;
		}
		StopCoroutine("MoveList");
		StartCoroutine("MoveList", -1);
	}


	/// <summary>
	/// 打开右边按钮
	/// </summary>
	public void OnBtnRight()
	{
		if (girdObj.transform.localPosition.x >= (girdRectTransform.sizeDelta.x - scrollTransform.sizeDelta.x) / 2)
		{
			girdObj.transform.localPosition = new Vector3((girdRectTransform.sizeDelta.x - scrollTransform.sizeDelta.x) / 2, 0, 0);
			return;
		}

		StopCoroutine("MoveList");
		StartCoroutine("MoveList", 1);
	}


	/// <summary>
	/// 移动Scroll
	/// </summary>
	/// <param name="dir">移动方向</param>
	/// <returns></returns>
	IEnumerator MoveList(int dir)
	{
		float all = 500;

		float oriX = girdObj.transform.localPosition.x;
		float targetX = oriX + dir * all;
		float start = Time.time;
		float last = 1f;
		while (Time.time < start + last)
		{
			girdObj.transform.localPosition = new Vector3(oriX + dir * all * (Time.time - start) / last, 0, 0);
			yield return null;
			if (girdObj.transform.localPosition.x > (girdRectTransform.sizeDelta.x - scrollTransform.sizeDelta.x) / 2)
			{
				girdObj.transform.localPosition = new Vector3((girdRectTransform.sizeDelta.x - scrollTransform.sizeDelta.x) / 2, 0, 0);
				break;
			}
			else if (girdObj.transform.localPosition.x < -(girdRectTransform.sizeDelta.x - scrollTransform.sizeDelta.x) / 2)
			{
				girdObj.transform.localPosition = new Vector3(-(girdRectTransform.sizeDelta.x - scrollTransform.sizeDelta.x) / 2, 0, 0);
				break;
			}
		}
	}
}
