using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using buildingTypes;

public class BuildingButtonBehavior : MonoBehaviour {

	public GameData data;
	public string buildingName;
	buildingType type = buildingType.blank;

	public bool bBuyable;

	Image comImage;

	// Use this for initialization
	void Start () {
		if (buildingName == "cursor") {
			type = buildingType.cursor;
		}
		bBuyable = false;
		comImage = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		bBuyable = data.bIsItBuyable(1, type);
		if (bBuyable == true) {
			comImage.color = Color.white;
		} else if (bBuyable == false) {
			comImage.color = Color.grey;
		}
	}

	public void OnClick() {
		if (bBuyable == true) {
			data.IncrementBuilding(1, type);
		}
	}
}
