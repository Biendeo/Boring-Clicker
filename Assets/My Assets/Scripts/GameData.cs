using UnityEngine;
using System.Collections;
using buildingClass;
using buildingTypes;

public class GameData : MonoBehaviour {

	// This is the amount of money the player currently has.
	public ulong numMoney = 0;

	Building cursors;
	
	void Start() {

		// This assigns the correct Building components to the variable names.
		// If you get a buttload of errors, either the building hasn't been implemented here, or the name is spelled wrong.
		// TODO Make these names defined somewhere.
		Building[] buildings = GetComponents<Building>();
		for (int i = 0; i < buildings.Length; i++) {
			switch (buildings[i].editorName) {
				case "cursor":
					cursors = buildings[i];
					Debug.Log("Cursor detected.");
					break;
				default:
					Debug.LogWarning("buildings[" + i + "] did not match anything.");
					break;
			}
		}

	}
	
	void Update() {
		// TODO Normalise the per-frame operation.
		BuildingUpdate(cursors);
	}

	// This function increases the amount of money the player owns by an amount.
	public void IncrementMoney(int incrementValue) {
		numMoney += (ulong)incrementValue;
	}

	// This function increases the amount of buildings bought by a given amount (and a given type.
	public void IncrementBuilding(int amount, buildingType type) {
		switch (type) {
			case buildingType.cursor:
				// TODO Change this so it incorporates different amounts.
				numMoney -= (ulong)cursors.costForNext;
				cursors.addToNum(amount);
				break;
			default:
				Debug.LogWarning("Something tried to access IncrementBuilding but didn't specify the type.");
				break;
		}
	}

	// This function updates the amount of time to the next building hit by the time it took to draw the frame.
	// If it hits 0, it resets and adds money.
	public void BuildingUpdate(Building building) {
		building.timeToHit -= Time.deltaTime;

		if (building.timeToHit <= 0) {
			IncrementMoney(building.getNum() * building.cashPerHit);
			building.timeToHit += building.timePerHit;
		}
	}

	// This function determines if the player can buy a certain amount of a building.
	public bool bIsItBuyable(int amount, buildingType type) {
		// TODO Calculate multiple buildings rather than just one.
		switch (type) {
			case buildingType.cursor:
				if (numMoney >= (ulong)cursors.costForNext) {
					return true;
				} else {
					return false;
				}
			default:
				Debug.LogWarning("Something tried to access bIsitBuyable but didn't specify the type.");
				return false;
		}
	}

	// This function gives number of buildings bought based on a given type.
	// To expand on this, add another case for each type of building.
	public int getNumOfBuilding(buildingType type) {
		switch (type) {
			case buildingType.cursor:
				return cursors.getNum();
			default:
				Debug.LogWarning("Something tried to access getNumOfBuilding but didn't specify the type.");
				return 0;
		}
		
	}

	public string printBuildingName(buildingType type) {
		switch (type) {
			case buildingType.cursor:
				return cursors.printName();
			default:
				Debug.LogWarning("Something tried to access printBuildingName but didn't specify the type.");
				return "";
		}
	}
}