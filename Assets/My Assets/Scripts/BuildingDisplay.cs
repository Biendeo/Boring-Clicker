using UnityEngine;
using System.Collections;

public class BuildingDisplay : MonoBehaviour {

	public GameObject buildingItem1;
	public GameObject buildingItem2;
	public GameObject buildingItem3;

	GameObject[] buildingItems;

	public GameData data;

	void Start () {
		buildingItems = GameObject.FindGameObjectsWithTag("Building Text Element");
		Debug.Log("I found " + buildingItems.Length + " objects.");
	}
	
	void Update () {
		// TODO This is not an easily modular way to do this. If possible, redo this part so that it automatically does it.
		if ((buildingItem1.activeSelf == false) && (data.bIsItBuyable(1, buildingTypes.buildingType.tier1) == true)) {
			buildingItem1.SetActive(true);
		}

		if ((buildingItem2.activeSelf == false) && (data.bIsItBuyable(1, buildingTypes.buildingType.tier2) == true)) {
			buildingItem2.SetActive(true);
		}

		if ((buildingItem3.activeSelf == false) && (data.bIsItBuyable(1, buildingTypes.buildingType.tier3) == true)) {
			buildingItem3.SetActive(true);
		}
	}
}
