using UnityEngine;

public class HealPotion : MonoBehaviour {

	public double healAmount;

	private void Start () {
		healAmount = GameObject.FindGameObjectWithTag ("Player").GetComponent<StatsHolder> ().HP * 0.1;
	}
}
