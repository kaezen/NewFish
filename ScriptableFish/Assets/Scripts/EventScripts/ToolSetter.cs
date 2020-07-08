using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSetter : SetterClass
{
    public fishEnums.ToolRequired ToolRequired;

    public override void TriggerEvent()
    {
        FishingEventsController.current.ChangeToolRequired(ToolRequired);
    }

    public void SetValueWithInt(int x)
    {
        ToolRequired = (fishEnums.ToolRequired)x;
    }
}
