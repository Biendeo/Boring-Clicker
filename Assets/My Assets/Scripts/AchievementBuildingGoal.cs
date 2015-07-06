using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using buildingTypes;

public class AchievementBuildingGoal : MonoBehaviour {
	
	public GameData data;

	public string goalName;
	public ulong goalValue;

	public string rewardName;
	public int rewardValue;

	public bool achieved;

	buildingType goalType;
	buildingType rewardType;

	Image comButton;
	
	void Start () {
		goalType = data.NameToType(goalName);
		rewardType = data.NameToType(rewardName);
		comButton = GetComponent<Image>();
	}
	
	void Update () {
		if (((ulong)data.getBuildingNum(goalType) >= goalValue) && (achieved == false)) {
			AchievementGet();
		}
	}

	public void AchievementGet() {
		achieved = true;
		data.MultiplyBuildingCPH(rewardValue, rewardType);
		comButton.color = new Color(0.7f, 0.9f, 0.7f, 1f);
	}
}
