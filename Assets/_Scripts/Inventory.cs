using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour {

	#region Singleton
	public static Inventory instance;

	private void Awake () {
		if (instance != null) {
			Debug.LogWarning ("More than one instance of Inventory launched");
		}
		instance = this;
	}
	#endregion

	public List<Item> items = new List<Item> ();

	private GameObject gameCanvas;

	[SerializeField]
	private GameObject textBox;

	private void Start () {
		gameCanvas = GameObject.FindGameObjectWithTag ("Canvas");
	}

	public void Add (Item item) {
		items.Add (item);
		textBox.GetComponent<TextMeshProUGUI> ().text = item.name;
		GameObject itemTextBox = Instantiate (textBox);
		itemTextBox.transform.SetParent (gameCanvas.transform);
		item.itemText = itemTextBox;
	}

	public void Remove (Item item) {
		Destroy (item.itemText);
		item.itemText = null;
		items.Remove (item);
	}

}
