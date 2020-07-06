using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOfDaySetter : SetterClass
{
    public fishEnums.TimeOfDay timeOfDay;

    public override void TriggerEvent()
    {
        FishingEvents.current.ChangeTimeOfDay(timeOfDay);
    }
}
