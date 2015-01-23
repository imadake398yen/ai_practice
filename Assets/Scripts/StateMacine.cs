using UnityEngine;
using System.Collections;

public class StateMacine : MonoBehaviour {

	public Transform other;

	enum STATE {
		ATTACK,
		CARE,
		SAFE
	}
	private STATE state = STATE.SAFE;
	
	void Start () {
	}
	
	void Update () {
		if (other) {

			Vector3 forward = transform.TransformDirection(Vector3.forward);
			Vector3 toOther = Vector3.Normalize(other.position - transform.position);
			float dot = Vector3.Dot(forward, toOther);
        	
			if (dot > 0.8f) {
				renderer.material.color = Color.red;
			}
			if (dot <= 0.8f && dot > 0.1f) {
				renderer.material.color = Color.yellow;
			}
			if (dot <= 0.1f) {
				renderer.material.color = Color.green;
			}
            
        }
	}
}
