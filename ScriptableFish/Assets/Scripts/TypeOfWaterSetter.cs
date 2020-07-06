using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeOfWaterSetter : SetterClass
{
    public fishEnums.BodyOfWaterType bodyOfWaterType;

    public override void TriggerEvent()
    {
        FishingEvents.current.ChangeBodyOfWater(bodyOfWaterType);
    }
}
