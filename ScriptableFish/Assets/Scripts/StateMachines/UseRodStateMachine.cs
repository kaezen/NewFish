﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseRodStateMachine : ToolStateMachine
{
    private CastingStateMachine _castingStateMachine;
    private EnticeStateMachine _enticeStateMachine;
    private RetrievalStateMachine _retrievalStateMachine;



    [SerializeField]
    private int _castingState;

    //TODO: Create reference to player's fishing rod
    public override void Initialize(UseItemStateMachine parent, ToolData tool, Transform location)
    {
        //Debug.Log("Let's go!");
        _fishingLocation = location;

        parentStateMachine = parent;
        PlayerTool = tool;
        CreateAssets();
        _castingState = 1;
    }

    //check the options the player has selected in his tool and generate components for that
    //create appropriate methods for each component of the tool
    public override void CreateAssets()
    {
        _castingStateMachine = CreateCastingRange();
        _castingStateMachine.Initialize(_fishingLocation);
        _enticeStateMachine = CreateEnticeMethod();
        _retrievalStateMachine = CreateRetrievalMethod();        
    }
    public override bool Execute()
    {
        switch (_castingState)
        {
            case 0://initial state
                CreateAssets();
                _castingState = 1;
                return true;
                break;
            case 1: //casting state
                _castingStateMachine.Execute();
                return true;
                break;
            case 2: 

                break;
            case 3:

                break;
        }
                return false;
    }


    public CastingStateMachine CreateCastingRange()
    {
        //casting range
        if (PlayerTool.CastingRange == fishEnums.CastingRange.Close)
        {
            Debug.Log("Found Casting: Close");
        }
        else if (PlayerTool.CastingRange == fishEnums.CastingRange.Far)
        {
            Debug.Log("Found Casting: Far");
        }
        return gameObject.AddComponent<CastingStateMachine>();
    }
    public EnticeStateMachine CreateEnticeMethod()
    {
        //entice method
        if (PlayerTool.EnticeMethod == fishEnums.EnticeMethod.Predictive)
        {
            Debug.Log("Found Entice: Predictive");
            //return gameObject.AddComponent<EnticePredictiveStateMachine>();
        }
        else if (PlayerTool.EnticeMethod == fishEnums.EnticeMethod.Rhythmic)
        {
            Debug.Log("Found Entice: Rhythmic");
        }
        else if (PlayerTool.EnticeMethod == fishEnums.EnticeMethod.Random)
        {
            Debug.Log("Found Entice: Random");
        }
        return gameObject.AddComponent<EnticeStateMachine>();
    }
    public RetrievalStateMachine CreateRetrievalMethod()
    {
        if (PlayerTool.RetrievalMethod == fishEnums.RetrievalMethod.Constant)
        {
            Debug.Log("Found Retrival: Constant");
        }
        else if (PlayerTool.RetrievalMethod == fishEnums.RetrievalMethod.Instant)
        {
            Debug.Log("Found Retrival: Instant");
        }
        else if (PlayerTool.RetrievalMethod == fishEnums.RetrievalMethod.OnOff)
        {
            Debug.Log("Found Retrival: On/Off");
        }
        return gameObject.AddComponent<RetrievalStateMachine>();

    }


    // Update is called once per frame
    void Update()
    {

    }

}
