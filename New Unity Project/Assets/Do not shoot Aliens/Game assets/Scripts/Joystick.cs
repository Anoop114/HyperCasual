using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Joystick : MonoBehaviour {
    
	public RectTransform center;
	public RectTransform knob;
	public float range;
	public bool fixedJoystick;
	
	[HideInInspector]
	public Vector2 direction;
	
	Vector2 start;
	
	void Start(){
		ShowHide(false);
	}
	
	void Update(){
		Vector2 pos = Input.mousePosition;
		
		if(Input.GetMouseButtonDown(0)){
			ShowHide(true);
			start = pos;
			
			knob.position = pos;
			center.position = pos;
		}
		else if(Input.GetMouseButton(0)){
			knob.position = pos;
			knob.position = center.position + Vector3.ClampMagnitude(knob.position - center.position, center.sizeDelta.x * range);
			
			if(knob.position != Input.mousePosition && !fixedJoystick){
				Vector3 outsideBoundsVector = Input.mousePosition - knob.position;
				center.position += outsideBoundsVector;
			}
			
			direction = (knob.position - center.position).normalized;
		}
		else if(Input.GetMouseButtonUp(0)){
			ShowHide(false);
			direction = Vector2.zero;
		}
	}
	
	void ShowHide(bool state){
		center.gameObject.SetActive(state);
		knob.gameObject.SetActive(state);
	}
}
