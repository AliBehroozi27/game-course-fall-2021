﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFreezerComboController : ComboInstanceController
{
    private UIManager UiManager;

    public void Start()
    {
        UiManager = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();
    }

    public override void OnConsume()
    {
        UiManager.onTimeFreezerConsume();
    }
}
