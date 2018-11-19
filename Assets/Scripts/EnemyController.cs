using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public Transform player;
	public float speed;
	public bool canMove = true;
	public int HP;
	public int DMG;

	void Update () {
		var lookDir = player.position - transform.position;
		lookDir.y = 0;
		transform.rotation = Quaternion.LookRotation (lookDir);
	}
}
