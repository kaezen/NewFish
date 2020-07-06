using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Fish", menuName ="New Fish")]
public class FishData : ScriptableObject
{
    public List<fishEnums.BodyOfWaterType> bodyOfWaterTypes = new List<fishEnums.BodyOfWaterType>();    
    public List<fishEnums.TimeOfDay> TimesOfDay = new List<fishEnums.TimeOfDay>();
    public List<fishEnums.Attractant> attractants = new List<fishEnums.Attractant>();
    public List<fishEnums.ToolRequired> toolsRequired = new List<fishEnums.ToolRequired>();
    public List<fishEnums.CastingRange> castingRanges = new List<fishEnums.CastingRange>();
    public List<fishEnums.EnticeMethod> enticeMethods = new List<fishEnums.EnticeMethod>();
    public List<fishEnums.RetrievalMethod> retrievalMethods = new List<fishEnums.RetrievalMethod>();

    
    public FishData()
    {
        bodyOfWaterTypes.Add(fishEnums.BodyOfWaterType.Any);
        TimesOfDay.Add(fishEnums.TimeOfDay.Any);
        attractants.Add(fishEnums.Attractant.Any);
        toolsRequired.Add(fishEnums.ToolRequired.Any);
        castingRanges.Add(fishEnums.CastingRange.Any);
        enticeMethods.Add(fishEnums.EnticeMethod.Any);
        retrievalMethods.Add(fishEnums.RetrievalMethod.Any);
    }
    
}
