using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventListener : MonoBehaviour
{
    public FishTest helper;

    // Start is called before the first frame update
    void Start()
    {
        FishingEvents.current.onChangeBodyOfWater += OnChangeBodyOfWater;
        FishingEvents.current.onChangeTimeOfDay += OnChangeTimeOfDay;
    }

    private void OnChangeBodyOfWater(fishEnums.BodyOfWaterType bodyOfWaterType)
    {
        helper.bodyOfWaterType = bodyOfWaterType;
        print("Recieving body of water: " + bodyOfWaterType);
    }
    private void OnChangeTimeOfDay(fishEnums.TimeOfDay timeOfDay)
    {
        helper.timeOfDay = timeOfDay;
        print("Recieving time of day: " + timeOfDay);
    }
}
