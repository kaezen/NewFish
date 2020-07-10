using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spear", menuName = "New Spear")]
public class ToolSpearData : ToolData
{
   public ToolSpearData()
    {
        ToolType = fishEnums.ToolRequired.Spear;
    }
    public override ToolStateMachine CreateStateMachine(GameObject parent)
    {
        ToolStateMachine stateMachine = parent.AddComponent<UseSpearStateMachine>();

        return stateMachine;
    }
}
