using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fishing Rod", menuName = "New Fishing Rod")]
public class ToolRodData : ToolData
{
    [Space(15)]
    public ToolEnums.CastType castingType = ToolEnums.CastType.none;
    public ToolRodData()
    {
        ToolType = fishEnums.ToolRequired.Rod;
    }
    public override ToolStateMachine CreateStateMachine(GameObject parent)
    {
        ToolStateMachine stateMachine = parent.AddComponent<UseRodStateMachine>();

        return stateMachine;
    }
    new public void OnValidate()
    {
        //check for any general validations from parent
        base.OnValidate();

        //and apply specific validations for this object
        if (castingType == ToolEnums.CastType.none)
        {
            Debug.LogError(this.name + " must have a specific casting type, not 'none'", this);
        }
    }
}
