using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Stats : MonoBehaviour {

	public ulong totalMoney;
	public uint totalBuildings;
	public ulong totalHits;
	public float totalTime;

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
		textTotalMoney.text = "Total Money: $" + totalMoney;
		textTotalBuildings.text = "Total Buildings: " + totalBuildings;
		textTotalHits.text = "Total Cash Hits: " + totalHits;
		textTotalTime.text = "Total Time Playing: " + totalTime;
	}
}
