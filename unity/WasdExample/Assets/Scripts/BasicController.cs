using UnityEngine;
using System.Collections;

public class BasicController : MonoBehaviour {

	private void Start() {
		if (useKeyboard) wasdStart();
		if (useMouse) mouseStart();
	}

	private void Update() {
		if (useKeyboard) wasdUpdate();
		if (useMouse) mouseUpdate();	
		if (useRaycaster) rayUpdate();	
	}

    // ~ ~ ~ ~ ~ ~ ~ ~ 

    [Header("Keyboard")] 
    public bool useKeyboard = true;
	public float walkSpeed = 10f;
	public float runSpeed = 100f;
	public float accel = 0.01f;
	//public float turnSpeed = 200f;
	public Transform homePoint;

	private float currentSpeed;
	private Vector3 p = Vector3.zero;
	private bool run = false;

	private void wasdStart() {
		currentSpeed = walkSpeed;
	}
	
	private void wasdUpdate() {
		if (Input.GetKeyDown(KeyCode.LeftShift)) {
			run = true;
		} else if (Input.GetKeyUp(KeyCode.LeftShift)) {
			run = false;
		}

		if (run && currentSpeed < runSpeed) {
			currentSpeed += accel;
			if (currentSpeed > runSpeed) currentSpeed = runSpeed;
		} else if (!run && currentSpeed > walkSpeed) {
			currentSpeed -= accel;
			if (currentSpeed < walkSpeed) currentSpeed = walkSpeed;
		}

		p.x = Input.GetAxis("Horizontal") * Time.deltaTime * currentSpeed;
		p.y = 0f;
		p.z = Input.GetAxis("Vertical") * Time.deltaTime * currentSpeed;

		//float mX = Input.GetAxis("Mouse X") * Time.deltaTime * turnSpeed;
		//float mY = Input.GetAxis("Mouse Y") * Time.deltaTime * turnSpeed;

		transform.Translate(p.x, p.y, p.z);

		//transform.Rotate(mY, mX, 0f);
		//Debug.Log(mX + " " + mY);	

		if (homePoint != null && Input.GetKeyDown(KeyCode.Home)){
			transform.position = homePoint.position;
			transform.rotation = homePoint.rotation;
			transform.localScale = homePoint.localScale;
		}
	}

	// ~ ~ ~ ~ ~ ~ ~ ~ 

	public enum RotationAxes { MouseXAndY, MouseX, MouseY };
    [Header("Mouse")]
    public bool useMouse = true;
    public bool showCursor = false;
	public bool useButton = true;
	public bool fixedZ = true;
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 2f;
	public float sensitivityY = 2f;
	public float minimumX = -360f;
	public float maximumX = 360f;
	public float minimumY = -60f;
	public float maximumY = 60f;
	public Vector3 mousePos = Vector3.zero;
	public bool clicked = false;
	public bool isDrawing = false;

	private float zPos = 1f;
	private float rotationY = 0f;

	private void mouseStart() {
        Cursor.visible = showCursor;
		if (GetComponent<Rigidbody>()) GetComponent<Rigidbody>().freezeRotation = true;
	}

	private void mouseUpdate() {
		if (axes == RotationAxes.MouseXAndY) {
			float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

			transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0f);
		} else if (axes == RotationAxes.MouseX) {
			transform.Rotate(0f, Input.GetAxis("Mouse X") * sensitivityX, 0f);
		} else {
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

			transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0f);
		}

		// ~ ~ ~

		clicked = false;

		if (useButton) {
			if (Input.GetMouseButtonDown(0) && GUIUtility.hotControl == 0) {
				clicked = true;
				isDrawing = true;
			}

			if (Input.GetMouseButton(0) && GUIUtility.hotControl == 0) {
				if (!fixedZ) zPos = lastHitPos.z;
				mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, zPos));
			}

			if (Input.GetMouseButtonUp(0)) {
				isDrawing = false;
			}
		}
	}

	// ~ ~ ~ ~ ~ ~ ~ ~ 

	[Header("Raycaster")]
	public bool useRaycaster = true;
	public bool isLooking = false;
	public string isLookingAt = "";
	public string tagName = "Clickable";
	public bool foundTagName = false;
	public bool followMouse = true;
	public Vector3 lastHitPos = Vector3.one;

	void rayUpdate() {
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
