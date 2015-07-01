using UnityEngine;
using System.Collections;

public class Sidebar : MonoBehaviour {
	
	void Start () {
	
	}
	
	void Update () {
	
	}

	public void TurnOffMenus() {
		SidebarButton[] buttons = GetComponentsInChildren<SidebarButton>();

		for (int i = 0; i < buttons.Length; i++) {
			switch (buttons[i].GetState()) {
				case true:
					buttons[i].Toggle();
					buttons[i].MenuToggle();
					break;
			}
		}
	}
}
