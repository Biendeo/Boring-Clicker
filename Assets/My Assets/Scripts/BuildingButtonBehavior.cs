using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using buildingTypes;

public class BuildingButtonBehavior : MonoBehaviour {

	public GameData data;

	public int buyAmount;

	public bool bBuyable;

	buildingType type = buildingType.blank;

	Image comImage;
	
	void Start () {
		BuildingText parentElement = GetComponentInParent<BuildingText>();
		type = data.NameToType(parentElement.buildingName);

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
