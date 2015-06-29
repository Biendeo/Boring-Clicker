using UnityEngine;
using System.Collections;

namespace buildingClass {
	public class Building : MonoBehaviour {

		public string editorName;
		public string singleName;
		public string pluralName;

		public int cashPerHit;
		public int timePerHit;
		public double timeToHit;
		public int costForNext; // I'm debating making this costForFirst, and then making a function to just return the value I want for this.
		public double increasePerUnit;

		int num;

		void Start() {
			num = 0;
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

		public int getTimePerHit() {
			return timePerHit;
		}

		public double getTimeToHit() {
			return timeToHit;
		}

		public int getcostForNext() {
			return cashPerHit;
		}

		public double getIncreasePerUnit() {
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