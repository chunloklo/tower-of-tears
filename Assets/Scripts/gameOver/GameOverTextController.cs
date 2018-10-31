using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverTextController : MonoBehaviour {

    public Text[] GameOverTexts;

	void Update () {
        GameOverTexts[0].text = CrossSceneInformation.GameOverTitle;
        GameOverTexts[1].text = CrossSceneInformation.GameOverSubtitle;
    }
}
