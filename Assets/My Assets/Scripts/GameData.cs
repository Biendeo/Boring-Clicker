using UnityEngine;
using System.Collections;
using buildingTypes;

public class GameData : MonoBehaviour {

	public const int cursorCPH = 1;
	public const int cursorTPH = 1;
	public const int cursorCFN = 20;
	public const double cursorIPU = 1.15;

	public ulong numMoney = 0;
	Building cursors = new Building(cursorCPH, cursorTPH, cursorCFN, cursorIPU);

	// Use this for initialization
	void Start() {

	}
	
	// Update is called once per frame
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
            cursors.num += amount;
		}
	}

	public void BuildingUpdate(Building building) {
		building.timeToHit -= Time.deltaTime;

		if (building.timeToHit <= 0) {
			numMoney += (ulong)(building.num * building.cashPerHit);
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

	public int getNumOfBuilding(buildingType type) {
		int num = 0;
		if (type == buildingType.cursor) {
			num = cursors.num;
		}

		return num;
	}
}

public class Building : MonoBehaviour {

	public int num;
	public int cashPerHit;
	public int timePerHit;
	public double timeToHit;
	public int costForNext;
	public double increasePerUnit;

	public Building(int CPH, int TPH, int CFN, double IPU) {
		num = 0;
		cashPerHit = CPH;
		timePerHit = TPH;
		increasePerUnit = IPU;
		timeToHit = timePerHit;
		costForNext = CFN;
	}

	void Start() {

	}
	
	void Update() {

	}
}

