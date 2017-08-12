using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotsManager : MonoBehaviour {

	public Dot dotPrefab;
	public int numDots = 50;

	[HideInInspector] public List<Dot> dots;

	private float spread = 1f;

	private void Start() {
		dots = new List<Dot>();
		setSpread();
		for (int i=0; i<numDots; i++) {
			Vector3 p = new Vector3(Random.Range(-spread, spread), Random.Range(-spread, spread), Random.Range(-spread/4f, spread/4f));
			Dot d = Instantiate(dotPrefab, p, Quaternion.identity);
			d.transform.SetParent(transform);
			d.name = "Dot" + (i+1);
			dots.Add(d);
		}
	}

	private void setSpread() {
		spread = Mathf.Abs(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f)).z);
	}

}
