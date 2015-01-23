using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

	public float rotateSpeed = 5f;

	void Update () {
		float h = Input.GetAxis("Horizontal");
		transform.eulerAngles += new Vector3(0f, h * Time.deltaTime * rotateSpeed, 0f);
	}
}
