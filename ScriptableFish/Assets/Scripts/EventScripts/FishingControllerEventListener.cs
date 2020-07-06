using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingControllerEventListener : MonoBehaviour
{
    public FishTest helper;

    // Start is called before the first frame update
    void Start()
    {
        FishingController.current.onStartFishing += OnStartFishing;
        FishingController.current.onChangeBodyOfWater += OnChangeBodyOfWater;
        FishingController.current.onChangeTimeOfDay += OnChangeTimeOfDay;
        FishingController.current.onChangeAttractant += OnChangeAttractant;
        FishingController.current.onChangeToolRequired += OnChangeToolRequired;
        FishingController.current.onChangeCastingRange += OnChangeCastingRange;
        FishingController.current.onChangeEnticeMethod += OnChangeEnticeMethod;
        FishingController.current.onChangeRetrievalMethod += OnChangeRetrievalMethod;
    }

    private void OnStartFishing()
    {
        helper.GoFishing();
        print("event recieved: Going Fishing");
    }

    private void OnChangeBodyOfWater(fishEnums.BodyOfWaterType bodyOfWaterType)
    {
        helper.BodyOfWaterType = bodyOfWaterType;
        print("Recieving body of water: " + bodyOfWaterType);
    }
    private void OnChangeTimeOfDay(fishEnums.TimeOfDay timeOfDay)
    {
        helper.TimeOfDay = timeOfDay;
        print("Recieving time of day: " + timeOfDay);
    }
    private void OnChangeAttractant(fishEnums.Attractant attractant)
    {
        helper.Attractant = attractant;
        print("Recieving attractant: " + attractant);
    }
    private void OnChangeToolRequired(fishEnums.ToolRequired tool)
    {
        helper.ToolRequired = tool;
        print("Recieving tool: " + tool);
    }
    private void OnChangeCastingRange(fishEnums.CastingRange castingRange)
    {
        helper.CastingRange = castingRange;
        print("Recieving casting range: " + castingRange);
    }
    private void OnChangeEnticeMethod(fishEnums.EnticeMethod enticeMethod)
    {
        helper.EnticeMethod = enticeMethod;
        print("Recieving entice method: " + enticeMethod);
    }
    private void OnChangeRetrievalMethod(fishEnums.RetrievalMethod retrievalMethod)
    {
        helper.RetrievalMethod = retrievalMethod;
        print("Recieving retrieval method: " + retrievalMethod);
    }
}
