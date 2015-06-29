using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using buildingTypes;

public class BuildingButtonText : MonoBehaviour {

	public GameData data;
	public int buyAmount;

	Text comText;
	buildingType type = buildingType.blank;

	void Start () {
		comText = GetComponent<Text>();
		type = transform.parent.GetComponent<BuildingButtonBehavior>().getBuildingType();

		if (type == buildingType.blank) {
			Debug.LogError("The button didn't get a building type!");
		}
	}
	
	void Update () {
		comText.text = "Get " + buyAmount + "\n" + "Cost: $" + data.getBuildingCostForNext(buyAmount, type);
	}
}
