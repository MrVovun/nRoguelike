using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public Transform player;
	public bool canMove = true;

	void FixedUpdate () {
		var lookDir = player.position - transform.position;
		lookDir.y = 0;
		transform.rotation = Quaternion.LookRotation (lookDir);

		if (GetComponent<StatsHolder> ().currentHP <= 0) {
			Death ();
		}
	}

	void Death () {
		Destroy (gameObject);
	}
}
