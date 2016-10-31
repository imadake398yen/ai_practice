using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public Transform target;

	[SerializeField]
	private int currentTarget = 0;

	[SerializeField]
	private Transform[] points;

	[SerializeField]
	private NavMeshAgent agent;

	enum STATE {
		ATTACK,
		CARE,
		SAFE
	}
	private STATE state = STATE.SAFE;
	
	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}
	
	void Update () {

		if (target) {
			// 自分が向いてる方向の角度(transform.forwardは元々正規化ベクトル)
			Vector3 forward = transform.forward;
			// 自分と対象との正規化ベクトル
			Vector3 toOther = Vector3.Normalize(target.position - transform.position);
			// 内積で2つの正規化ベクトルをとることで自分と対象との角度が求められる
			float dot = Vector3.Dot(forward, toOther);

			print (dot);
        	
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
				GetComponent<Renderer>().material.color = Color.green;
				//ここにSAFE時の処理を書く
				if (Vector3.Distance(transform.position, target.position) < 0.2f) {
					if (currentTarget < points.Length-1) {
						currentTarget += 1;
					}
					else currentTarget = 0;
				}
				target = points[currentTarget];
				break;
			case STATE.CARE:
				GetComponent<Renderer>().material.color = Color.yellow;
				//CARE時の処理
				break;
			case STATE.ATTACK:
				GetComponent<Renderer>().material.color = Color.red;
				//ATTACK時の処理
				break;
		}

		if (target != null) {
			agent.SetDestination(target.position);
		}
		
	}

}
