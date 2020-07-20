using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CastingStateMachine : MonoBehaviour
{
    //TODO: functionality... starting with initial idea for casting

    [SerializeField]
    private CastingChasingStateMachineResources resources;

    public GameObject Prefab;

    [SerializeField]
    public int _fishingState = 0;


    public abstract void Initialize(Transform location, ToolComponentReferences references);
    public abstract bool Execute();

    public abstract void SetValues();

    private void OnDestroy()
    {
        Destroy(Prefab);
    }
}
