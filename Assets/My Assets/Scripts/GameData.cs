using UnityEngine;
using System.Collections;
using buildingClass;
using buildingTypes;

public class GameData : MonoBehaviour {

	public const int cursorCPH = 1;
	public const int cursorTPH = 1;
	public const int cursorCFN = 20;
	public const double cursorIPU = 1.15;

	public ulong numMoney = 0;

	Building cursors;
	
	void Start() {

		// T
		Building[] buildings = GetComponents<Building>();
		for (int i = 0; i < buildings.Length; i++) {
			switch (buildings[i].name) {
				case "cursor":
					cursors = buildings[i];
					break;
			}
		}
	}
	
	void Update() {
		BuildingUpdate(cursors);
	}

	public void IncrementMoney(int incrementValue) {
		numMoney += (ulong)incrementValue;
	}

	public void IncrementBuilding(int amount, buildingType type) {
		if (type == buildingType.cursor) {
			// Change this so it incorporates different amounts.
			numMoney -= (ulong)cursors.costForNext;
            cursors.addToNum(amount);
		}
	}

	public void BuildingUpdate(Building building) {
		building.timeToHit -= Time.deltaTime;

		if (building.timeToHit <= 0) {
			numMoney += (ulong)(building.getNum() * building.cashPerHit);
			building.timeToHit += building.timePerHit;
		}
	}

	public bool bIsItBuyable(int amount, buildingType type) {
		bool bBuyable = false;

		if (type == buildingType.cursor) {
			if (numMoney >= (ulong)cursors.costForNext) {
				bBuyable = true;
			}
		}

		return bBuyable;
	}

	// This function gives number of buildings bought based on a given type.
	// To expand on this, add another case for each type of building.
	public int getNumOfBuilding(buildingType type) {
		switch(type) {
			case buildingType.cursor:
				return cursors.getNum();
		}
		
		Debug.Log("Something tried to access getNumOfBuilding but didn't specify the type.");
		return 0;
	}
}