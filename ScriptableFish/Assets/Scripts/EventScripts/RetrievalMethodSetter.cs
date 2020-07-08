using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetrievalMethodSetter : SetterClass
{

    public fishEnums.RetrievalMethod RetrievalMethod;

    public override void TriggerEvent()
    {
        FishingEventsController.current.ChangeRetrievalMethod(RetrievalMethod);
    }

    public void SetValueWithInt(int x)
    {
        RetrievalMethod = (fishEnums.RetrievalMethod)x;
    }
}
