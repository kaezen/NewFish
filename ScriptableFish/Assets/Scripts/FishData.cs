using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Fish", menuName ="New Fish")]
public class FishData : ScriptableObject
{
    public new string name;

    public List<fishEnums.BodyOfWaterType> bodyOfWaterTypes;    
    public List<fishEnums.TimeOfDay> TimesOfDay;
    public List<fishEnums.Attractant> attractants;
    public List<fishEnums.ToolRequired> toolsRequired;
    public List<fishEnums.CastingRange> castingRanges;
    public List<fishEnums.EnticeMethod> enticeMethods;
    public List<fishEnums.RetrievalMethod> retrievalMethods;

    /*
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
    */
}
