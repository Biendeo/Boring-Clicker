using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using buildingTypes;

public class BuildingText : MonoBehaviour {

	public GameData data;
	public string buildingName;
	Text comText;
	buildingType type = buildingType.blank;

	string printString;

	// Use this for initialization
	void Start () {
		comText = GetComponent<Text>();
		if (buildingName == "cursor") {
			type = buildingType.cursor;
			printString = "cursors";
		}
	}
	
	// Update is called once per frame
	void Update () {
		comText.text = data.getNumOfBuilding(type) + " " + printString;
	}
}