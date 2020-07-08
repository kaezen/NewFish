using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyOfWaterSetter : SetterClass
{
    public fishEnums.BodyOfWaterType BodyOfWaterType;

    public override void TriggerEvent()
    {
        FishingEventsController.current.ChangeBodyOfWater(BodyOfWaterType);
    }
    public void SetValueWithInt(int x)
    {
        BodyOfWaterType = (fishEnums.BodyOfWaterType)x;        
    }
}
