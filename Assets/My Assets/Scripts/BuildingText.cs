using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using buildingTypes;

public class BuildingText : MonoBehaviour {

	public GameData data;
	public string buildingName;
	Text textName;
	Text textMoney;
	Text textTime;
	buildingType type = buildingType.blank;
	
	void Start () {
		Text[] textElements = GetComponentsInChildren<Text>();
		for (int i = 0; i < textElements.Length; i++) {
			switch (textElements[i].text) {
				case "BUILDING TEXT":
					textName = textElements[i];
					break;
				case "$1":
					textMoney = textElements[i];
					break;
				case "50.0s":
					textTime = textElements[i];
					break;
			}
		}

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
		textName.text = data.getBuildingNum(type) + " " + data.printBuildingName(type);
		textMoney.text = "$" + (data.getBuildingCashPerHit(type) * data.getBuildingNum(type));
		textTime.text = data.getBuildingTimeToHit(type).ToString("F1") + "s";
	}
}