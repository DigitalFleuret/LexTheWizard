﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateBackgroundState : MonoBehaviour {
    public static UpdateBackgroundState INSTANCE;
    public Image background;

	[SerializeField]
	Sprite[] caveBackgrounds;
	[SerializeField]
	Sprite[] forestBackgrounds;
	[SerializeField]
	Sprite[] hillBackgrounds;
	[SerializeField]
	Sprite[] swampBackgrounds;

	Sprite[][] terrainBackgrounds;

	void Awake() {
        if (INSTANCE == null) {
            INSTANCE = this;
			InitBackgrounds();
        }
    }

	void InitBackgrounds () {
		// Arrays are organized based on the GameController.Terrain enum
		terrainBackgrounds = new Sprite[][]{
			swampBackgrounds,
			hillBackgrounds,
			forestBackgrounds,
			caveBackgrounds
		};
	}

    void OnEnable() {
		Fungus.Flowchart.BroadcastFungusMessage("UpdateBackgroundStateStart");
    }

	void Update () {
		UpdateBackground();
		GameController.INSTANCE.NextState();
	}

    public void UpdateBackground () {
		int terrainIndex = (int) GameController.INSTANCE.currentTerrain;
		int timeOfDayIndex = (int) GameController.INSTANCE.currentDayTime;
		try {
			background.sprite = terrainBackgrounds[terrainIndex][timeOfDayIndex];
		} catch (System.Exception e) {
			Debug.LogErrorFormat("Error: {0}, [{1}, {2}] is not a valid index", e, terrainIndex, timeOfDayIndex);
		}
	}
}