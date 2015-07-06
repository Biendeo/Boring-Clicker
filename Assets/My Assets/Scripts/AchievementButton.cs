using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AchievementButton : MonoBehaviour {

	public GameData data;
	public AchievementTextDisplay textObject;

	public string achievementName;
	public string achievementText;

	void Start () {

	}
	
	void Update () {

	}

	public void MouseEnter() {
		textObject.PrintAchievement(achievementName + ": " + achievementText);
	}

	public void MouseExit() {
		textObject.DefaultText();
	}
}
