using UnityEngine;
using System.Collections;

namespace buildingClass {
	public class Building : MonoBehaviour {

		int num;
		public string editorName;
		public int cashPerHit;
		public int timePerHit;
		public double timeToHit;
		public int costForNext;
		public double increasePerUnit;

		void Start() {
			num = 0;
			cashPerHit = 0;
			timePerHit = 0;
			increasePerUnit = 0;
			timeToHit = timePerHit;
			costForNext = 0;
		}

		void Update() {

		}

		public int getNum() {
			return num;
		}

		public int addToNum(int addValue) {
			num += addValue;
			return num;
		}
	}
}