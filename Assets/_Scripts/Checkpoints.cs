using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Checkpoints : MonoBehaviour {

	#region Singleton
	public static Checkpoints instance;

	private void Awake () {
		if (instance != null) {
			Debug.LogWarning ("More than one instance of Checkpoints launched");
		}
		instance = this;
	}
	#endregion

	public List<Transform> checkpoints = new List<Transform> ();

	private void Start () {
		foreach (GameObject point in GameObject.FindGameObjectsWithTag ("Checkpoint")) {

			checkpoints.Add (point.transform);
		}
	}
}
