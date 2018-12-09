using UnityEngine;

[CreateAssetMenu (fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

	new public string name = "NewItem";
	public Sprite icon = null;
	public string type;
	public GameObject itemText;
}
