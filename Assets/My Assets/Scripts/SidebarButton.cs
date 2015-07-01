using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SidebarButton : MonoBehaviour {

	public GameData data;
	public GameObject buildingViewObject;
	public GameObject menuObject;

	public string mainText;
	string closeText = "Close";

	bool bMenuOpen = false;

	Text comText;
	Image comImage;

	void Start () {
		comText = GetComponentInChildren<Text>();
		comImage = GetComponent<Image>();
	}
	
	void Update () {
	
	}

	public void OnClick() {
		Toggle();

		switch (bMenuOpen) {
			case true:
				comText.text = closeText;
				comImage.color = new Color(0.7f, 0.9f, 0.7f, 1f);
				buildingViewObject.SetActive(false);
				menuObject.SetActive(true);
				break;
			case false:
				comText.text = mainText;
				comImage.color = Color.white;
				buildingViewObject.SetActive(true);
				menuObject.SetActive(false);
				break;
		}
	}

	public bool Toggle() {
		switch (bMenuOpen) {
			case true:
				bMenuOpen = false;
				break;
			case false:
				bMenuOpen = true;
				break;
		}

		return bMenuOpen;
	}
}
