using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingPulsingStateMachine : CastingStateMachine
{
    //TODO: functionality... starting with initial idea for casting

    [SerializeField]
    private CastingPulsingStateMachineResources _resources;

    private GameObject _fishingTarget;
    private GameObject _fishingProgress;
    private GameObject _castingTarget;

    private float _minimumScale;
    private float _maxScale;

    //TODO: Replace this when get scriptable object reference working
    private float _initialCastingSpeed;

    [Tooltip("How fast the ring pulses, less than 1 for slower, greater than 1 to go faster.")]
    private float _pulseRate;

    [Tooltip("This is how long the player has to finish.")]
    //[SerializeField]
    private float _progressTimerBase = 10;
    private float _progressTimer = 0;

    public override void Initialize(Transform location, ToolComponentReferences references)
    {
        _resources = references.CastingComponentList.PulsingResources;
        //   GameObject g = GameObject.Find("CastingPulsing");
        //_helper = Instantiate(resources.castingPrefab, location.transform.position, location.transform.rotation, this.transform);
        // _helper = Instantiate(g, location.transform.position, location.transform.rotation, this.transform);
        Prefab = Instantiate(_resources.CastingPulsingPrefab, location.transform.position, location.transform.rotation);
        CastingComponentHolder c = Prefab.GetComponent<CastingComponentHolder>();

        _fishingTarget = c.FishingTarget;
        _fishingProgress = c.FishingProgress;
        _castingTarget = c.CastingTarget;


        _fishingProgress.SetActive(false);
        _castingTarget.SetActive(false);

        SetValues();
        _fishingState = 1;
    }

    public override void SetValues()
    {
        _initialCastingSpeed = _resources.InitialCastingSpeed;
        _progressTimerBase = _resources.TimeToFinishCast;
        _minimumScale = _resources.MinimumScale;
        _maxScale = _resources.MaxScale;
        _pulseRate = _resources.PulseRate;
    }

    public override bool Execute()
    {
        switch (_fishingState)
        {
            //going out / targeting
            case 1:
                if (Input.GetMouseButton(0))
                {
                    //Debug.Log("Going out");
                    _fishingTarget.transform.position += _fishingTarget.transform.forward * _initialCastingSpeed * Time.deltaTime;
                }
                if (Input.GetMouseButtonUp(0))
                {
                    //_progressTimer = 0;
                    _fishingProgress.SetActive(true);
                    _fishingProgress.transform.position = _fishingTarget.transform.position;
                    _castingTarget.SetActive(true);
                    _fishingTarget.SetActive(true);
                    _castingTarget.transform.position = _fishingTarget.transform.position;
                    _fishingTarget.transform.localScale = Vector3.one * 2;

                    _fishingState = 2;
                }
                return true;

            //Scaling the orb
            case 2:
                //float size = Mathf.Sin(Time.deltaTime) * _oscilationMultiplier;
                float size = Mathf.PingPong(Time.time * _pulseRate, _maxScale) + _minimumScale;

                _castingTarget.transform.localScale = new Vector3(size, .05f, size);

                //counting time              
                _progressTimer += Time.deltaTime;

                if (_progressTimer >= _progressTimerBase)
                {
                    _fishingState = 3;
                }

                if (Input.GetMouseButtonDown(0))
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
