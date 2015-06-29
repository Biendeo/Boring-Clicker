using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using buildingTypes;

public class BuildingText : MonoBehaviour {

	public GameData data;
	public string buildingName;
	Text comText;
	buildingType type = buildingType.blank;
	
	void Start () {
		comText = GetComponent<Text>();
		switch (buildingName) {
			case "cursor":
				type = buildingType.cursor;
				break;
			case "grandma":
				type = buildingType.grandma;
				break;
			default:
				Debug.LogWarning("A building doesn't have a valid name tied to it.");
				break;
		}
	}
	
	void Update () {
		comText.text = data.getBuildingNum(type) + " " + data.printBuildingName(type) + " ($" + (data.getBuildingCashPerHit(type) * data.getBuildingNum(type)) + " in " + data.getBuildingTimeToHit(type).ToString("F2") + " seconds)";
	}
}