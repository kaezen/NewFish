using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteAlways]
public class FishTest : MonoBehaviour
{
    [Tooltip("The list of fish in the game. Make sure to update it if you have made more fish!")]
    public FishDataCollection fishList;
    [Space(20)]

    public fishEnums.BodyOfWaterType bodyOfWaterType;
    public fishEnums.TimeOfDay timeOfDay;
    public fishEnums.Attractant attractant;
    public fishEnums.ToolRequired toolRequired;
    public fishEnums.CastingRange castingRange;
    public fishEnums.EnticeMethod enticeMethod;
    public fishEnums.RetrievalMethod retrievalMethod;

    [Space(10)]
    public List<FishData> fishAvailableToCatch;

    [Space(10)]    
    public FishData caughtFish;

    [Space(20)]
    List<FishData> listOfFishToCatch;

    private void Update()
    {
       // if (Input.GetKeyDown(KeyCode.Return)) GoFishing();
    }

    public void GoFishing()
    {
        listOfFishToCatch.Clear();
       
        foreach(FishData f in fishList.fishList)
        {
            listOfFishToCatch.Add(f);
        }

        print("Going fishing");
        fishAvailableToCatch.Clear();
        caughtFish = null;

        //take the list of fish we have
        foreach (FishData f in listOfFishToCatch)
        {
            Debug.Log("Checking fish: " + f.name);
            //bool addFish = false;

            //we are going to assume the fish will be added to the list
            //if it turns out the fish does not match the components required
            //it will instead not be added and we move to the next fish

        //compare all the parameters to weed out possibilities
     
        //region below works**
            #region
            //check body of water
            if (f.bodyOfWaterTypes.Contains(bodyOfWaterType) 
                || f.bodyOfWaterTypes.Contains(fishEnums.BodyOfWaterType.Any) 
                || bodyOfWaterType == fishEnums.BodyOfWaterType.Any)
            {
                //check time of day
                if (f.TimesOfDay.Contains(timeOfDay) 
                    || f.TimesOfDay.Contains(fishEnums.TimeOfDay.Any) 
                    || timeOfDay == fishEnums.TimeOfDay.Any)
                {
                    //check attractant
                    if (f.attractants.Contains(attractant) 
                        || f.attractants.Contains(fishEnums.Attractant.Any) 
                        || attractant == fishEnums.Attractant.Any)
                    {
                        //check tool
                        if (f.toolsRequired.Contains(toolRequired) 
                            || f.toolsRequired.Contains(fishEnums.ToolRequired.Any) 
                            || toolRequired == fishEnums.ToolRequired.Any)
                        {
                            //check casting range
                            if (f.castingRanges.Contains(castingRange) 
                                || f.castingRanges.Contains(fishEnums.CastingRange.Any) 
                                || castingRange == fishEnums.CastingRange.Any)
                            {
                                fishAvailableToCatch.Add(f);                                
                            }
                        }
                    }
                }
            }
            #endregion
        }
     
        
        //randomly select fish
        if (fishAvailableToCatch.Count != 0)
        {
            int i = Random.Range(0, fishAvailableToCatch.Count);
            Debug.Log(i);
            caughtFish = fishAvailableToCatch[i];
            //return caught fish
        }
    }
}
[CustomEditor(typeof(FishTest))]
public class FishTestEditor : Editor
{
    public override void OnInspectorGUI()
    {
        FishTest fishingMenu = (FishTest)target;
        if (GUILayout.Button("Go Fishing!"))
        {
            fishingMenu.GoFishing();
            //Debug.Log("test");
        }
        DrawDefaultInspector();
    }
}
