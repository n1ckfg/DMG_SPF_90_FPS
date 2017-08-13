using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour {

    public Explosion explosionPrefab;
	public float scale = 100f;
	public float spread = 10f;
	public Color clickColor;
	public Color hoverColor;

    [HideInInspector] public bool alive = true;
    [HideInInspector] public float clickTime = 0f;

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
            if (ctl.clicked) {
                Explosion explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                explosion.transform.SetParent(transform.parent);
                alive = false;
                clickTime = Time.realtimeSinceStartup;
            }
		} else if (ctl.isLookingAt == gameObject.name && !ctl.isDrawing) {
			ren.material.color = hoverColor;
		} else {
			ren.material.color = origColor;
		}
	}

}
