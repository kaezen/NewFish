using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CastingComponents", menuName = "Test/0CastingComponents")]
public class CastingStateMachineComponents : ScriptableObject
{
    public CastingChasingStateMachineResources ChasingResources;
    public CastingWaitingStateMachineResources WaitingResources;
    public CastingPulsingStateMachineResources PulsingResources;
}
