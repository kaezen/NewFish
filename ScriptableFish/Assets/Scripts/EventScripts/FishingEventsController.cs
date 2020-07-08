using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FishingEventsController : MonoBehaviour
{
    public static FishingEventsController current;
    private void Awake()
    {
        if(current != this) current = this;
    }

    public event Action onStartFishing;

    public void StartFishing()
    {
        if(onStartFishing != null)
        {
            onStartFishing();
        }
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

    public event Action<fishEnums.Attractant> onChangeAttractant;
    public void ChangeAttractant(fishEnums.Attractant attractant)
    {
        if(onChangeAttractant != null)
        {
            onChangeAttractant(attractant);
        }
    }

    public event Action<fishEnums.ToolRequired> onChangeToolRequired;
    public void ChangeToolRequired(fishEnums.ToolRequired tool)
    {
        if(onChangeToolRequired != null)
        {
            onChangeToolRequired(tool);
        }
    }
    public event Action<fishEnums.CastingRange> onChangeCastingRange;
    public void ChangeCastingRange(fishEnums.CastingRange castingRange)
    {
        if(onChangeCastingRange != null)
        {
            onChangeCastingRange(castingRange);
        }
    }
    public event Action<fishEnums.EnticeMethod> onChangeEnticeMethod;
    public void ChangeEnticeMethod(fishEnums.EnticeMethod enticeMethod)
    {
        if(onChangeEnticeMethod != null)
        {
            onChangeEnticeMethod(enticeMethod);
        }
    }
    public event Action<fishEnums.RetrievalMethod> onChangeRetrievalMethod;
    public void ChangeRetrievalMethod(fishEnums.RetrievalMethod retrievalMethod)
    {
        if(onChangeRetrievalMethod != null)
        {
            onChangeRetrievalMethod(retrievalMethod);
        }
    }
}
