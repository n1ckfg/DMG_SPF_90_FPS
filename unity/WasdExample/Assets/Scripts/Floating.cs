using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour {

	public float divider = 100f;

	void Start() {
		divider = Random.Range(divider - (divider/10f), divider + (divider/10f));
	}
	
	void Update() {
		transform.Translate(0f, Mathf.Sin(Time.realtimeSinceStartup)/divider, 0f);
	}

}
