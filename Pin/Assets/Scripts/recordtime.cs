﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class recordtime : MonoBehaviour {
    float timer = 0;
    public Text timerText; 
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        timerText.text = ((int)timer).ToString() + "秒";
    }
}
