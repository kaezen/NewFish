﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFishingTrigger : SetterClass
{
    public override void TriggerEvent()
    {
        FishingController.current.StartFishing();
    }
}