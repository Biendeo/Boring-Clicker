using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using buildingTypes;

public class BuildingButtonBehavior : MonoBehaviour {

	public GameData data;
	public string buildingName;

	public int buyAmount;

	public bool bBuyable;

	buildingType type = buildingType.blank;

	Image comImage;
	
	void Start () {
		switch (buildingName) {
			case "cursor":
				type = buildingType.cursor;
				break;
			case "grandma":
				type = buildingType.grandma;
				break;
		}

		bBuyable = false;
		comImage = GetComponent<Image>();
	}
	
	void Update () {
		bBuyable = data.bIsItBuyable(buyAmount, type);
		if (bBuyable == true) {
			comImage.color = Color.white;
		} else if (bBuyable == false) {
			comImage.color = Color.grey;
		}
	}

	public void OnClick() {
		if (bBuyable == true) {
			data.IncrementBuilding(buyAmount, type);
		}
	}

	public buildingType getBuildingType() {
		return type;
	}
}
