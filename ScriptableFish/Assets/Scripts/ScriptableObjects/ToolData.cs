using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ToolData : ScriptableObject
{
    [Tooltip("Do not leave this on 'Any' or 'None'")]
    public fishEnums.ToolRequired ToolType = fishEnums.ToolRequired.None;
    public fishEnums.CastingRange CastingRange = fishEnums.CastingRange.Any;
    public fishEnums.EnticeMethod EnticeMethod = fishEnums.EnticeMethod.Any;
    public fishEnums.RetrievalMethod RetrievalMethod = fishEnums.RetrievalMethod.Any;

    public void OnValidate()
    {
        if (ToolType == fishEnums.ToolRequired.Any || ToolType == fishEnums.ToolRequired.None)
        {
            Debug.LogError(this.name + " must have a specific tooltype, not 'Any' or 'None'.", this);
        }
    }

    public abstract ToolStateMachine CreateStateMachine(GameObject parent);    
}
