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
	}
	
	void Update () {
		// TODO Ideally, this only needs to run once. The problem is, void Start() is before the parent's void Start(),
		// which means it won't the value it wants. If this can be solved, move this out of void Update().
		type = GetComponentInParent<BuildingButtonBehavior>().getBuildingType();
		if (type == buildingType.blank) {
			Debug.LogError("The button didn't get a building type!");
		}

		comText.text = "Get " + buyAmount + "\n$" + data.getBuildingCostForNext(buyAmount, type);
	}
}
