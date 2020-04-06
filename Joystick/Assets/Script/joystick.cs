using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class joystick : MonoBehaviour {

	// Use this for initialization
	private Camera UICamera;
	public Canvas canvas;
	private Image image;
	private Vector2 screenV;
	private Vector2 oldvector3;
	private Vector3 offsetdetal;
	private Vector2 defualtVec;
	private Vector2 defulatRect;
	private Vector2 pos;
	
	void Start () {
		UICamera = this.gameObject.GetComponent<Camera>();
		image = canvas.transform.Find("Image").GetComponent<Image>();
		image.gameObject.SetActive(false);
		defualtVec = new Vector2(image.rectTransform.rect.width, image.rectTransform.rect.height);
		defulatRect = image.rectTransform.anchoredPosition;
	}
	public Vector2 XY(Vector3 v)
	{
		return new Vector2(v.x, v.y);
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			screenV = XY(Input.mousePosition);
			image.gameObject.SetActive(true);
			pos = screenV;
			image.rectTransform.position = screenV;
		}
		if (Input.GetMouseButton(0))
		{
			screenV = XY(Input.mousePosition);
			
			offsetdetal = screenV - pos;
			float angle = Mathf.Atan2(offsetdetal.y, offsetdetal.x) * (180 / Mathf.PI);
			
			if (offsetdetal.magnitude >= defualtVec.x)
			{
				image.rectTransform.sizeDelta = new Vector2(offsetdetal.magnitude, image.rectTransform.rect.height);
			}
			else
			{ 
				image.rectTransform.sizeDelta = defualtVec;
			}
			image.rectTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

		}
		if (Input.GetMouseButtonUp(0))
		{
			image.rectTransform.anchoredPosition = defulatRect;
			image.rectTransform.sizeDelta = defualtVec;
			image.gameObject.SetActive(false);
		}
	}
}
