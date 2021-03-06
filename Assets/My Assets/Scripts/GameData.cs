﻿using UnityEngine;
using System.Collections;
using buildingClass;
using buildingTypes;

public class GameData : MonoBehaviour {
	// This is the amount of money the player currently has.
	public ulong numMoney = 0;
	
	// This tracks the building components that are also in this gameObject.
	// Add buildings by attaching the component, and adding necessary parts to NameToType() and TypeToName().
	// Also add a type to BuildingTypes.cs.
	Building[] buildings;

	ulong totalMoney = 0;
	float totalTime = 0;
	ulong totalBuildings = 0;
	ulong totalHits = 0;
	
	void Start() {
		buildings = GetComponents<Building>();
	}
	
	void Update() {
		for (int i = 0; i < buildings.Length; i++) {
			BuildingUpdate(buildings[i]);
		}

		totalTime += Time.deltaTime;
	}

	// This function updates the amount of time to the next building hit by the time it took to draw the frame.
	// If it hits 0, it resets and adds money.
	public void BuildingUpdate(Building building) {
		if (building.getNum() > 0) {
			building.timeToHit -= Time.deltaTime;

			if (building.timeToHit <= 0) {
				IncrementMoney(building.getNum() * building.cashPerHit);
				building.timeToHit += building.timePerHit;

				totalMoney += (uint)(building.getNum() * building.cashPerHit);
				totalHits++;
			}
		}
	}

	// This function increases the amount of money the player owns by an amount.
	public void IncrementMoney(int incrementValue) {
		numMoney += (ulong)incrementValue;
		totalMoney += (ulong)incrementValue;
	}

	// This function converts the name of a building to its relative buildingType.
	public buildingType NameToType(string name) {
		switch (name) {
			case "tier1":
				return buildingType.tier1;
			case "tier2":
				return buildingType.tier2;
			case "tier3":
				return buildingType.tier3;
			case "all":
				return buildingType.all;
			default:
				return buildingType.blank;
		}
	}

	// This function converts the buildingType of a building to its relative name.
	public string TypeToName(buildingType type) {
		switch (type) {
			case buildingType.tier1:
				return "tier1";
			case buildingType.tier2:
				return "tier2";
			case buildingType.tier3:
				return "tier3";
			default:
				return "null";
		}
	}

	// This function converts a type to the specific index of where it is stored.
	int BuildingTypeToIndex(buildingType type) {
		int index = -1;
		for (int i = 0; i < buildings.Length; i++) {
			if (buildings[i].editorName == TypeToName(type)) {
				index = i;
				break;
			}
		}

		return index;
	}

	// This function increases the amount of buildings bought by a given amount (and a given type.
	public void IncrementBuilding(int amount, buildingType type) {
		int index = BuildingTypeToIndex(type);

		numMoney -= buildings[index].getCostForNext(amount);
		buildings[index].addToNum(amount);

		totalBuildings++;
	}

	public void MultiplyBuildingCPH(int amount, buildingType type) {
		int index = BuildingTypeToIndex(type);

		buildings[index].MultiplyCPH(amount);
	}


	// This function determines if the player can buy a certain amount of a building.
	public bool bIsItBuyable(int amount, buildingType type) {
		int index = BuildingTypeToIndex(type);

		if (numMoney >= buildings[index].getCostForNext(amount)) {
			return true;
		} else {
			return false;
		}
	}

	// This function gives number of buildings bought based on a given type.
	// To expand on this, add another case for each type of building.
	public int getBuildingNum(buildingType type) {
		int index = BuildingTypeToIndex(type);

		return buildings[index].getNum();
	}

	// This function returns the cost of a given building.
	public ulong getBuildingCostForNext(int amount, buildingType type) {
		int index = BuildingTypeToIndex(type);

		return buildings[index].getCostForNext(amount);
	}

	// This function returns the cash per hit of a given building
	public int getBuildingCashPerHit(buildingType type) {
		int index = BuildingTypeToIndex(type);

		return buildings[index].getCashPerHit();
	}

	// This function returns the name of a given building type.
	public double getBuildingTimeToHit(buildingType type) {
		int index = BuildingTypeToIndex(type);

		return buildings[index].getTimeToHit();
	}

	// This function returns the name of a given building type.
	public string printBuildingName(buildingType type) {
		int index = BuildingTypeToIndex(type);

		return buildings[index].printName();
	}

	public ulong getTotalMoney() {
		return totalMoney;
	}

	public float getTotalTime() {
		return totalTime;
	}

	public ulong getTotalBuildings() {
		return totalBuildings;
	}

	public ulong getTotalHits() {
		return totalHits;
	}
}