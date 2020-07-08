using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingControllerEventListener : MonoBehaviour
{
    public FishTest helper;

    // Start is called before the first frame update
    void Start()
    {
        FishingEventsController.current.onStartFishing += OnStartFishing;
        FishingEventsController.current.onChangeBodyOfWater += OnChangeBodyOfWater;
        FishingEventsController.current.onChangeTimeOfDay += OnChangeTimeOfDay;
        FishingEventsController.current.onChangeAttractant += OnChangeAttractant;
        FishingEventsController.current.onChangeToolRequired += OnChangeToolRequired;
        FishingEventsController.current.onChangeCastingRange += OnChangeCastingRange;
        FishingEventsController.current.onChangeEnticeMethod += OnChangeEnticeMethod;
        FishingEventsController.current.onChangeRetrievalMethod += OnChangeRetrievalMethod;
    }

    //TODO: potentially put this trigger farther down the line, only resolving fish gotten when fishing is completed
    //TODO: OR: put the 'return fish' on a separate event trigger
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
