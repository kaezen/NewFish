using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CastingStateMachine : MonoBehaviour
{
    //TODO: functionality... starting with initial idea for casting

    [SerializeField]
    private CastingStateMachineResources resources;

    public GameObject _helper;


    private GameObject _fishingTarget;
    private GameObject _fishingProgress;
    private GameObject _launchArc;
    private GameObject _castingTarget;


    [SerializeField]
    private int _fishingState = 0;


    public abstract void Initialize(Transform location, ToolComponentReferences references);
    public abstract bool Execute();
}
