using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public float lifeTime = 5f;

    private float startTime = 0f;

	void Start() {
        startTime = Time.realtimeSinceStartup;
	}
	
	void Update() {
		if (Time.realtimeSinceStartup > startTime + lifeTime) {
            Destroy(gameObject);
        }
	}

}
