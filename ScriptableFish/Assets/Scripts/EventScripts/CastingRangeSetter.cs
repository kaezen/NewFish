using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingRangeSetter : SetterClass
{
    
    public fishEnums.CastingRange CastingRange;

    public override void TriggerEvent()
    {
        FishingEventsController.current.ChangeCastingRange(CastingRange);
    }

    public void SetValueWithInt(int x)
    {
        CastingRange = (fishEnums.CastingRange)x;
    }
}
