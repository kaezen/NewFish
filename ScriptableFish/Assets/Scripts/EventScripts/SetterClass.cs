using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SetterClass : MonoBehaviour
{
    bool isOverlapping = false;
    
    //TODO: Create variable to hold the fishEnum.type we want to set
    private void OnTriggerEnter(Collider other)
    {
        print("I hit a thing!:" + other.name);
        isOverlapping = true;
    }
    private void OnTriggerExit(Collider other)
    {
        isOverlapping = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOverlapping)
        {
            // print("Setting water: " + bodyOfWaterType);
            TriggerEvent();
        }
    }

    //invoke the event associated with the fishEnum type
    public abstract void TriggerEvent();
}
