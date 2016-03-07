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
				state = STATE.ATTACK;
			}
			if (dot <= 0.8f && dot > 0.1f) {
				state = STATE.CARE;
			}
			if (dot <= 0.1f) {
				state = STATE.SAFE;
			}
		}
		
		switch (state) {
			case STATE.SAFE:
				renderer.material.color = Color.red;
				//ここにSAFE時の処理を書く
				break;
			case STATE.CARE:
				renderer.material.color = Color.yellow;
				//CARE時の処理
				break;
			case STATE.ATTACK:
				renderer.material.color = Color.green;
				//ATTACK時の処理
				break;
		}
		
	}

}
