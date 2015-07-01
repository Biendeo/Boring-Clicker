using UnityEngine;
using System.Collections;

public class BuildingDisplay : MonoBehaviour {

	public GameObject buildingItem1;
	public GameObject buildingItem2;
	public GameObject buildingItem3;
	public GameData data;

	void Start () {
	
	}
	
	void Update () {
		// TODO This is not an easily modular way to do this. If possible, redo this part so that it automatically does it.
		if ((buildingItem1.activeSelf == false) && (data.bIsItBuyable(1, buildingTypes.buildingType.cursor) == true)) {
			Debug.Log("Cursors should appear.");
			buildingItem1.SetActive(true);
		}

		if ((buildingItem2.activeSelf == false) && (data.bIsItBuyable(1, buildingTypes.buildingType.grandma) == true)) {
			buildingItem2.SetActive(true);
		}

		if ((buildingItem3.activeSelf == false) && (data.bIsItBuyable(1, buildingTypes.buildingType.grandma) == true)) {
			buildingItem3.SetActive(true);
		}
	}
}
