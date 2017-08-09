using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour {

	public Color newColor;

	private BasicController ctl;
	private Renderer ren;
	private Color origColor;

	void Awake() {
		ren = GetComponent<Renderer>();
		origColor = ren.material.color;
		ctl = GameObject.FindGameObjectWithTag("Player").GetComponent<BasicController>();
	}
	
	void Update() {
		if (ctl.isLookingAt == gameObject.name && ctl.isDrawing) {
			ren.material.color = newColor;
		} else {
			ren.material.color = origColor;
		}
	}

}
