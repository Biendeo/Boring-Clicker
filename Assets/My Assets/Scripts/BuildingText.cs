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
			default:
				Debug.Log("A building doesn't have a valid name tied to it.");
				break;
		}
	}
	
	void Update () {
		comText.text = data.getNumOfBuilding(type) + " " + data.printBuildingName(type);
	}
}