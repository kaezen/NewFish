using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractantSetter : SetterClass
{
    public fishEnums.Attractant Attractant;    

    public override void TriggerEvent()
    {
        FishingEventsController.current.ChangeAttractant(Attractant);
    }

    public void SetValueWithInt(int x)
    {        
        Attractant = (fishEnums.Attractant)x;
    }
}
