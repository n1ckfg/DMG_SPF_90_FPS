using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour {

	public Color newColor;
	private Raycaster raycaster;
	private Renderer ren;
	private Color origColor;

	void Awake() {
		ren = GetComponent<Renderer>();
		origColor = ren.material.color;
		raycaster = Camera.main.GetComponent<Raycaster>();
	}
	
	void Update() {
		if (raycaster.foundTagName && raycaster.isLookingAt == gameObject.name) {
			ren.material.color = newColor;
		} else {
			ren.material.color = origColor;
		}
	}

}
