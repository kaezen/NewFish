using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteAlways]
public class FishTest : MonoBehaviour
{
    [Tooltip("The list of fish in the game. Make sure to update it if you have made more fish!")]
    public FishDataCollection fishList;

    public fishEnums.BodyOfWaterType BodyOfWaterType 
    {
        get { return _bodyOfWaterType; } 
        set { _bodyOfWaterType = value; }
    }
    public fishEnums.TimeOfDay TimeOfDay 
    {
        get { return _timeOfDay; }
        set { _timeOfDay = value; }
    }
    public fishEnums.Attractant Attractant
    {
        get { return _attractant; }
        set { _attractant = value; }
    }
    public fishEnums.ToolRequired ToolRequired
    {
        get { return _toolRequired; }
        set { _toolRequired = value;  }
    }
    public fishEnums.CastingRange CastingRange
    {
        get { return _castingRange; }
        set { _castingRange = value; } 
    }
    public fishEnums.EnticeMethod EnticeMethod
    {
        get { return _enticeMethod; }
        set { _enticeMethod = value; }
    }
    public fishEnums.RetrievalMethod RetrievalMethod
    {
        get { return _retrievalMethod; }
        set { _retrievalMethod = value; }
    }
    
   [SerializeField]
    private fishEnums.BodyOfWaterType _bodyOfWaterType;    
   [SerializeField]
    private fishEnums.TimeOfDay _timeOfDay;    
   [SerializeField]
    private fishEnums.Attractant _attractant;    
   [SerializeField]
    private fishEnums.ToolRequired _toolRequired;    
   [SerializeField]
    private fishEnums.CastingRange _castingRange;    
   [SerializeField]
    private fishEnums.EnticeMethod _enticeMethod;    
   [SerializeField]
    private fishEnums.RetrievalMethod _retrievalMethod;

    [Space(10)]
    [SerializeField]
    private List<FishData> _fishAvailableToCatch = new List<FishData>();

    [Space(10)]
    public FishData caughtFish;

    [Space(20)]
    List<FishData> listOfFishToCatch = new List<FishData>();

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Return)) GoFishing();
    }

    public void GoFishing()
    {
        listOfFishToCatch.Clear();

        foreach (FishData f in fishList.fishList)
        {
            listOfFishToCatch.Add(f);
        }

        print("Going fishing");
        _fishAvailableToCatch.Clear();
        caughtFish = null;

        //take the list of fish we have
        foreach (FishData f in listOfFishToCatch)
        {
            //Debug.Log("Checking fish: " + f.name);
            
            //compare all the parameters to weed out possibilities

            //region below works**
            #region
            //check body of water
            if (f.bodyOfWaterTypes.Contains(_bodyOfWaterType)
                || f.bodyOfWaterTypes.Contains(fishEnums.BodyOfWaterType.Any)
                || _bodyOfWaterType == fishEnums.BodyOfWaterType.Any)
            {
                //check time of day
                if (f.TimesOfDay.Contains(_timeOfDay)
                    || f.TimesOfDay.Contains(fishEnums.TimeOfDay.Any)
                    || _timeOfDay == fishEnums.TimeOfDay.Any)
                {
                    //check attractant
                    if (f.attractants.Contains(_attractant)
                        || f.attractants.Contains(fishEnums.Attractant.Any)
                        || _attractant == fishEnums.Attractant.Any)
                    {
                        //check tool
                        if (f.toolsRequired.Contains(_toolRequired)
                            || f.toolsRequired.Contains(fishEnums.ToolRequired.Any)
                            || _toolRequired == fishEnums.ToolRequired.Any)
                        {
                            //check casting range
                            if (f.castingRanges.Contains(_castingRange)
                                || f.castingRanges.Contains(fishEnums.CastingRange.Any)
                                || _castingRange == fishEnums.CastingRange.Any)
                            {
                                _fishAvailableToCatch.Add(f);
                            }
                        }
                    }
                }
            }
            #endregion
        }

        //final step of catching fish
        ReturnCaughtFish();
    }

    private FishData ReturnCaughtFish()
    {
        //randomly select fish
        if (_fishAvailableToCatch.Count != 0)
        {
            int i = Random.Range(0, _fishAvailableToCatch.Count);
            //Debug.Log(i);
            caughtFish = _fishAvailableToCatch[i];
            Debug.Log("You caught a: " + caughtFish);
            return caughtFish;
            //return caught fish
        }

        else
        {
            Debug.LogError("ERROR! no fish was caught");
            return null;
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
