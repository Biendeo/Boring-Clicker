using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyText : MonoBehaviour {

	public GameData data;
	public string displayString;
	Text comText;
	
	void Start () {
		comText = GetComponent<Text>();
	}
	
	void Update () {
		comText.text = displayString + data.numMoney;
	}
}
