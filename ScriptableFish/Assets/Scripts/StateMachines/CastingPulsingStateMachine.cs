using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingPulsingStateMachine : CastingStateMachine
{
    //TODO: functionality... starting with initial idea for casting

    [SerializeField]
    private CastingStateMachineResources resources;

    private GameObject _fishingTarget;
    private GameObject _fishingProgress;
    private GameObject _castingTarget;

    [SerializeField]
    private float _minimumScale = .25f;
    [SerializeField]
    private float _oscilationMultiplier = 2;

    [SerializeField]
    private int _fishingState = 0;

    //TODO: Replace this when get scriptable object reference working
    [SerializeField]
    private float _initialCastingSpeed = 5;

    //[Tooltip("This is how long it takes for the progress circle to catch up to the target")]
    //[SerializeField]
    //private float _progressTimerBase = 10;
    //private float _progressTimer = 0;

    public override void Initialize(Transform location, ToolComponentReferences references)
    {
        GameObject g = GameObject.Find("CastingPulsing");
        //_helper = Instantiate(resources.castingPrefab, location.transform.position, location.transform.rotation, this.transform);
        _helper = Instantiate(g, location.transform.position, location.transform.rotation, this.transform);
        CastingComponentHolder c = _helper.GetComponent<CastingComponentHolder>();
        _fishingTarget = c.FishingTarget;
        _fishingProgress = c.FishingProgress;
        _castingTarget = c.CastingTarget;

        _fishingProgress.SetActive(false);
        _castingTarget.SetActive(false);

        _fishingState = 1;
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
                    _castingTarget.transform.parent = null;
                    _fishingTarget.SetActive(true);
                    _castingTarget.transform.position = _fishingTarget.transform.position;
                    _fishingTarget.transform.localScale = Vector3.one * 2;                    

                    _fishingState = 2;
                }
                return true;
                break;

            //Scaling the orb
            case 2:
                //float size = Mathf.Sin(Time.deltaTime) * _oscilationMultiplier;
                float size = Mathf.PingPong(Time.time, _oscilationMultiplier) + _minimumScale;

                _castingTarget.transform.localScale = new Vector3(size, .05f, size);


                //counting time              
                //_progressTimer += Time.deltaTime;

                // if (_fishingProgress.transform.localPosition.z >= _fishingTarget.transform.localPosition.z)
                // {
                //     _fishingState = 3;
                // }

                if (Input.GetMouseButtonDown(0))
                {
                    _fishingState = 3;
                }
                return true;
                break;
            case 3:
                print("DONE WITH CASTING STEP!!");
                return false;
                break;
        }
        return false;
    }
}
