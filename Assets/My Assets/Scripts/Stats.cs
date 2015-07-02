using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Stats : MonoBehaviour {

	public GameData data;
	Text textTotalMoney;
	Text textTotalBuildings;
	Text textTotalHits;
	Text textTotalTime;

	void Start () {
		Text[] textObjects = GetComponentsInChildren<Text>();

		for (int i = 0; i < textObjects.Length; i++) {
			switch (textObjects[i].text) {
				case "Total Money":
					textTotalMoney = textObjects[i];
					break;
				case "Total Buildings":
					textTotalBuildings = textObjects[i];
					break;
				case "Total Hits":
					textTotalHits = textObjects[i];
					break;
				case "Total Time":
					textTotalTime = textObjects[i];
					break;
			}
		}
	}
	
	void Update () {



		textTotalMoney.text = "Total Money: $" + data.getTotalMoney();
		textTotalBuildings.text = "Total Buildings: " + data.getTotalBuildings();
		textTotalHits.text = "Total Cash Hits: " + data.getTotalHits();
		textTotalTime.text = "Total Time Playing: " + (ulong)data.getTotalTime() + "s";
	}
}
