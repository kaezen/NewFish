using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FishingEvents : MonoBehaviour
{
    public static FishingEvents current;
    private void Awake()
    {
        if(current != this) current = this;
    }

    public event Action<fishEnums.BodyOfWaterType> onChangeBodyOfWater;
    public void ChangeBodyOfWater(fishEnums.BodyOfWaterType bodyOfWaterType)
    {
        if (onChangeBodyOfWater != null)
        {
            onChangeBodyOfWater(bodyOfWaterType);
        }
    }

    public event Action<fishEnums.TimeOfDay> onChangeTimeOfDay;
    public void ChangeTimeOfDay(fishEnums.TimeOfDay timeOfDay)
    {
        if(onChangeTimeOfDay != null)
        {
            onChangeTimeOfDay(timeOfDay);
        }
    }
}
