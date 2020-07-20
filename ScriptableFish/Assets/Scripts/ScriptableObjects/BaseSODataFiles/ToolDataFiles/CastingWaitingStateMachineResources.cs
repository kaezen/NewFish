using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "CastingWaitingResources", menuName ="Test/2CastingWaitingResources")]
public class CastingWaitingStateMachineResources : ScriptableObject
{
    [Header("The objects this casting method needs.")]
    public GameObject CastingWaitingPrefab;
    public CastingComponentHolder CastingWaitingComponents;


    [Header("The properties for this casting method.")]
    [Tooltip("How fast the initial target for 'where I want to fish' goes outward.")]
    [Range(1, 20)]
    public float InitialCastingSpeed = 1;

    [Tooltip("How long it takes to finish this casting method.")]
    [Range(1, 30)]
    public float TimeToFinishCast =1;

    [Space(5)]

    [Tooltip("The base amount of force applied to the pull")]
    [Range(.5f, 10)]
    public float PullForceBase;

    [Tooltip("How much the force can vary (+ or - this number) from the base. \n" +
        "RECOMMEND: having this + base be less than player force.")]
    [Range(.5f, 10)]
    public float PullForceRange;

    [Space(5)]

    [Tooltip("The amount of force the player fights back with. More force means more control")]
    [Range(1, 20)]
    public float PlayerForce;

    [Space(5)]

    [Tooltip("How long (in seconds) between when the pull force triggers")]
    [Range(.5f, 10)]
    public float TimeBetweenPulls;


    [Tooltip("Varience (+ or - this number) from the base time between pulls./n DO NOT make this less than the base!")]
    [Range(.5f,5)]
    public float TimeBetweenPullsRange = .5f;

    [Tooltip("How long the fighting force will pull for.")]
    [Range(.5f, 10)]
    public float PullDuration;

    [Tooltip("Varience (+ or - this number) from the base duration of a pull./n DO NOT make this less than the base!")]
    [Range(.5f, 5)]
    public float PullDurationRange = .5f;

    [Space(5)]

    [Tooltip("The Size of the sphere")]
    [Range(.1f, 2f)]
    public float CastingTargetSize = .15f;

    [Tooltip("Turn this off to hide the casting arc.")]
    public bool ShowCastingArc = true;

    private void OnValidate()
    {
        if (TimeBetweenPullsRange >= TimeBetweenPulls)
        {
            Debug.LogError("ERROR: TimeBetweenPulls range must be smaller than the base value!");
        }
        if (PullDurationRange >= TimeBetweenPulls)
        {
            Debug.LogError("ERROR: PullDuration range must be smaller than the base value!");
        }
    }
}
