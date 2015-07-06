using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AchievementTextDisplay : MonoBehaviour {

	Text comText;
	public string defaultText;
	
	void Start () {
		comText = GetComponent<Text>();
		comText.text = defaultText;
	}
	
	void Update () {
	
	}

	public void PrintAchievement(string displayString) {
		comText.text = displayString;
	}

	public void DefaultText() {
		comText.text = defaultText;
	}
}
