using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "CastingPulsingResources", menuName = "Test/3CastingPulsingResources")]
public class CastingPulsingStateMachineResources : ScriptableObject
{
    [Header("The objects this casting method needs.")]
    public GameObject CastingPulsingPrefab;
    public CastingComponentHolder CastingPulsingComponents;


    [Header("The properties for this casting method.")]
    [Tooltip("How fast the initial target for 'where I want to fish' goes outward.")]
    [Range(1, 20)]
    public float InitialCastingSpeed = 1;

    [Tooltip("How long the player has to finish (in seconds).")]
    [Range(1, 30)]
    public float TimeToFinishCast = 5;

    [Space(5)]

    [Tooltip("The minimum size of the ring. /n DO NOT make this smaller than maximum!")]
    [Range(.1f, 5)]
    public float MinimumScale = .25f;

    [Tooltip("The max size of the ring. /n DO NOT make this smaller than minimum!")]
    [Range(1, 8)]
    public float MaxScale = 2;

    [Space(5)]

    [Tooltip("How fast the ring pulses, less than 1 to make slower, greater than 1 to make faster")]
    [Range(.01f, 20)]
    public float PulseRate = 1;

    private void OnValidate()
    {
        if(MinimumScale >= MaxScale)
        {
            Debug.LogError("ERROR: Max Scale must be GREATER than Minimum Scale");
        }
    }
}