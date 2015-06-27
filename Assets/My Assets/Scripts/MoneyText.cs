using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyText : MonoBehaviour {

	public GameData data;
	Text comText;

	// Use this for initialization
	void Start () {
		comText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		comText.text = "Money: $" + data.numMoney;
	}
}
