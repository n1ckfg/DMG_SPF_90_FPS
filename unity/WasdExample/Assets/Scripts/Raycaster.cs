using UnityEngine;
using System.Collections;

public class Raycaster : MonoBehaviour {

	public bool isLooking = false;
	public string isLookingAt = "";
	public string tagName = "Clickable";
	public bool foundTagName = false;
	public bool followMouse = true;
	public Vector3 lastHitPos = Vector3.zero;

	void Update() {
		RaycastHit hit;
		Ray ray;
		
		if (followMouse) {
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		} else {
			ray = new Ray(transform.position, transform.forward);
		}
		
		if (Physics.Raycast(ray, out hit)) {
			isLooking = true;
			isLookingAt = hit.collider.name;

			lastHitPos = hit.point;

			if (hit.collider.gameObject.tag == tagName) {
				foundTagName = true;
			} else {
				foundTagName = false;
			}
		} else {
			isLooking = false;
			isLookingAt = "";
			foundTagName = false;
		}
	}

}
