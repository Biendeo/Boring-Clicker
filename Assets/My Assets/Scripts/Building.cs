﻿using UnityEngine;
using System.Collections;

namespace buildingClass {
	public class Building : MonoBehaviour {

		public string editorName;
		public string singleName;
		public string pluralName;

		public int cashPerHit;
		public double timePerHit;
		public double timeToHit;
		public int costForFirst;
		public double increasePerUnit;

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

		public double getTimePerHit() {
			return timePerHit;
		}

		public double getTimeToHit() {
			return timeToHit;
		}
		
		public int getCostForNext() {
			return (int)(costForFirst * Mathf.Pow((float)getIncreasePerUnit(), getNum()));
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