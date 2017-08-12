using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour {

	public float scale = 100f;
	public float spread = 10f;
	public Color clickColor;
	public Color hoverColor;

	private BasicController ctl;
	private Renderer ren;
	private Color origColor;

	void Awake() {
		ren = GetComponent<Renderer>();
		ctl = Camera.main.GetComponent<BasicController>();
	}

	void Start() {
		origColor = ren.material.color;
		scale = Random.Range(scale - spread, scale + spread);
	}

	void Update() {
		transform.Translate(0f, Mathf.Sin(Time.realtimeSinceStartup)/scale, 0f);

		if (ctl.isLookingAt == gameObject.name && ctl.isDrawing) {
			ren.material.color = clickColor;
		} else if (ctl.isLookingAt == gameObject.name && !ctl.isDrawing) {
			ren.material.color = hoverColor;
		} else {
			ren.material.color = origColor;
		}
	}

}
