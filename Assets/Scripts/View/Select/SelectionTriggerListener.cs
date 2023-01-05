using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LayoutElement))]
public class SelectionTriggerListener : EventTriggerListener
{

	private Vector2 currentSize;
	private Vector2 targetSize;
	private float speed = 4.0f;

	private void Start()
	{
		targetSize = currentSize = new Vector2(this.GetComponent<LayoutElement>().preferredWidth, this.GetComponent<LayoutElement>().preferredHeight);
	}

	private void Update()
	{
		if (currentSize != targetSize)
		{
			currentSize = Vector2.Lerp(currentSize, targetSize, Time.deltaTime * speed);
			if (Vector2.Distance(currentSize, targetSize) <= 0.01)
			{
				currentSize = targetSize;
			}

			this.GetComponent<LayoutElement>().preferredWidth = currentSize.x;
			this.GetComponent<LayoutElement>().preferredHeight = currentSize.y;
		}
	}

	public void UpdateSize(Vector2 size, float speed)
	{
		this.targetSize = size;
		this.speed = speed;
	}
}
