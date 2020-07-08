using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOfDaySetter : SetterClass
{
    public fishEnums.TimeOfDay TimeOfDay;

    public override void TriggerEvent()
    {
        FishingEventsController.current.ChangeTimeOfDay(TimeOfDay);
    }

    public void SetValueWithInt(int x)
    {
        TimeOfDay = (fishEnums.TimeOfDay)x;        
    }
}
