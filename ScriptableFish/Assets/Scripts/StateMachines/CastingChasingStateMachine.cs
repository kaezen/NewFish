using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingChasingStateMachine : CastingStateMachine
{
    [SerializeField]
    private CastingChasingStateMachineResources _resources;    
    private ToolComponentReferences _resourceList;

    [SerializeField]
    private GameObject _fishingTarget;
    [SerializeField]
    private GameObject _fishingProgress;
    [SerializeField]
    private GameObject _castingArc;
    [SerializeField]
    private GameObject _castingTarget;


    //TODO: Replace this when get scriptable object reference working
    [SerializeField]
    private float _initialCastingSpeed = 5;

    [Tooltip("This is how long it takes for the progress circle to catch up to the target")]
    [SerializeField]
    private float _timeToReachTargetBase;
    private float _timeToReachTargetTimer = 0;

    [Tooltip("Minimum amount of force applied")]
    [SerializeField]
    private float _pullForceBase;

    [Tooltip("This is the max amount of force that can pull away (+ or - this value)" +
        " Recommend having this less than player force.")]
    [SerializeField]
    private float _pullForceRange;
    [SerializeField]
    private float _playerForce;

    [Tooltip("How long (in seconds) between when the fighting force triggers")]
    [SerializeField]
    private float _timeBetweenPullsBase;    
    private float _timeBetweenPullsTimer = 0;

    [Tooltip("Varience (+ or - this number) from the base time between pulls")]
    [SerializeField]
    private float _timeBetweenPullsOffset;
    
    
    [Tooltip("How long the fighting force will pull for.")]
    [SerializeField]
    private float _pullForceDurationTimerBase;
    [SerializeField]
    private float _pullForceDurationTimer = 0;

    [Tooltip("Varience (+ or - this number) from the base duration of a pull")]
    private float _pullForceDurationOffset;
    
    private Vector3 _pullForce = Vector3.zero;

    private Vector3 _startPos;

    public override void Initialize(Transform location, ToolComponentReferences references)
    {
        _resources = references.CastingComponentList.ChasingResources;

        Prefab = Instantiate(_resources.CastingChasingPrefab, location.transform.position, location.transform.rotation);
        CastingComponentHolder c = Prefab.GetComponent<CastingComponentHolder>();
         _fishingTarget = c.FishingTarget;
         _fishingProgress = c.FishingProgress;
         _castingArc = c.CastingArc;
         _castingTarget = c.CastingTarget;

        _castingTarget.SetActive(false);
        _castingArc.SetActive(false);
        _fishingProgress.SetActive(false);

        SetValues();

        _fishingState = 1;
    }

    public override void SetValues()
    {
        _initialCastingSpeed = _resources.InitialCastingSpeed;
        _timeToReachTargetBase = _resources.TimeToReachTarget;
        _pullForceBase = _resources.PullForceBase;
        _pullForceRange = _resources.PullForceRange;
        _playerForce = _resources.PlayerForce;
        _timeBetweenPullsBase = _resources.TimeBetweenPulls;
        _timeBetweenPullsOffset = _resources.TimeBetweenPullsRange;
        _pullForceDurationTimerBase = _resources.TimeBetweenPulls;
        _pullForceDurationOffset = _resources.PullDurationRange;

        _castingTarget.transform.localScale = _resources.CastingTargetSize * Vector3.one;
    }

    public override bool Execute()
    {
        switch (_fishingState)
        {
            //going out / targeting
            case 1:
                if (Input.GetMouseButton(0))
                {
                    Debug.Log("Going out");
                    _fishingTarget.transform.position += _fishingTarget.transform.forward * _initialCastingSpeed * Time.deltaTime;
                }
                if (Input.GetMouseButtonUp(0))
                {
                    _castingTarget.SetActive(true);
                    if(_resources.ShowCastingArc) _castingArc.SetActive(true);
                    _fishingProgress.SetActive(true);

                    _timeBetweenPullsTimer = _timeBetweenPullsBase;
                    _pullForce = Vector3.zero;
                    _startPos = _fishingProgress.transform.position;
                    _fishingState = 2;
                    _timeToReachTargetTimer = 0;
                }
                return true;

            //chasing the target
            case 2:
                //moving the target sphere           

                _timeBetweenPullsTimer -= Time.deltaTime;
                if (_timeBetweenPullsTimer < 0)
                {
                    if (_pullForce == Vector3.zero)
                    {
                        float r = 0;
                        r = Random.Range(-1, 1);
                        float x = (Random.Range(0, _pullForceRange) + _pullForceBase) * r;
                        r = Random.Range(-1, 1);
                        float z = (Random.Range(0, _pullForceRange) + _pullForceBase) * r;

                        _pullForce = new Vector3(x, 0, z);
                    }
                    _pullForceDurationTimer -= Time.deltaTime;
                    _timeBetweenPullsTimer = 0;
                    //_castingTarget.transform.position += _fightingForce * Time.deltaTime;

                    if (_pullForceDurationTimer <= 0)
                    {
                        _timeBetweenPullsTimer = _timeBetweenPullsBase + Random.Range(-_timeBetweenPullsOffset, _timeBetweenPullsOffset);
                        _pullForceDurationTimer = _pullForceDurationTimerBase + Random.Range(-_pullForceDurationOffset, _pullForceDurationOffset);
                        _pullForce = Vector3.zero;
                    }
                }

                //apply player controls
                Vector3 playerInputForce = Vector3.zero;
                if (Input.GetKey(KeyCode.W)) playerInputForce += _castingTarget.transform.forward;
                if (Input.GetKey(KeyCode.A)) playerInputForce += -_castingTarget.transform.right;
                if (Input.GetKey(KeyCode.S)) playerInputForce += -_castingTarget.transform.forward;
                if (Input.GetKey(KeyCode.D)) playerInputForce += _castingTarget.transform.right;

                playerInputForce *= _playerForce;
                playerInputForce += _pullForce;

                _castingTarget.transform.position += playerInputForce * Time.deltaTime;

                //moving the progress circle               
                _timeToReachTargetTimer += Time.deltaTime;
                _fishingProgress.transform.position = Vector3.Lerp(_startPos, _fishingTarget.transform.position, _timeToReachTargetTimer / _timeToReachTargetBase);

                //scaling the arc
                float arcSize = _timeToReachTargetTimer / _timeToReachTargetBase * _fishingTarget.transform.localPosition.z;
                _castingArc.transform.localScale = new Vector3(1, arcSize, arcSize);


                if (_fishingProgress.transform.localPosition.z >= _fishingTarget.transform.localPosition.z)
                {
                    _fishingState = 3;
                }
                return true;
            case 3:
                print("DONE WITH CASTING STEP!!");
                return false;
        }
        return false;
    }
}
