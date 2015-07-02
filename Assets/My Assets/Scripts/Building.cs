using UnityEngine;
using System.Collections;

namespace buildingClass {
	public class Building : MonoBehaviour {

		public string editorName;
		public string singleName;
		public string pluralName;

		public int cashPerHit;
		public float timePerHit;
		public float timeToHit;
		public int costForFirst;
		public float increasePerUnit;

		int num;

		void Start() {
			num = 0;
			timeToHit = timePerHit;
		}

		void Update() {

		}

		public int addToNum(int addValue) {
			num += addValue;
			return num;
		}

		public int getNum() {
			return num;
		}

		public int getCashPerHit() {
			return cashPerHit;
		}

		public float getTimePerHit() {
			return timePerHit;
		}

		public float getTimeToHit() {
			return timeToHit;
		}
		
		// This function returns how much it will cost to buy an amount of buildings.
		// The formula is cost = firstCost * (increase ^ num).
		public ulong getCostForNext(int amount) {
			ulong cost = 0;

			for (int i = 0; i < amount;  i++) {
				cost += (ulong)(costForFirst * Mathf.Pow(getIncreasePerUnit(), getNum() + i));
            }

			return cost;
		}

		public float getIncreasePerUnit() {
			return increasePerUnit;
		}

		public string printName() {
			switch (getNum()) {
				case 1:
					return singleName;
				default:
					return pluralName;
			}
		}
	}
}