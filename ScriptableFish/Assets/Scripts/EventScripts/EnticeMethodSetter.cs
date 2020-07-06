using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnticeMethodSetter : SetterClass
{

    public fishEnums.EnticeMethod EnticeMethod;

    public override void TriggerEvent()
    {
        FishingController.current.ChangeEnticeMethod(EnticeMethod);
    }

    public void SetValueWithInt(int x)
    {
        EnticeMethod = (fishEnums.EnticeMethod)x;
    }
}
