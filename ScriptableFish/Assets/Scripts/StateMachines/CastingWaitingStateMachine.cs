using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingWaitingStateMachine : CastingStateMachine
{
    //TODO: functionality... starting with initial idea for casting

    [SerializeField]
    private CastingStateMachineResources resources;

    private GameObject _fishingTarget;
    private GameObject _fishingProgress;
    private GameObject _launchArc;
    private GameObject _castingTarget;


    [SerializeField]
    private int _fishingState = 0;

    //TODO: Replace this when get scriptable object reference working
    [SerializeField]
    private float _initialCastingSpeed = 5;

    [Tooltip("This is how long it takes for the progress circle to catch up to the target")]
    [SerializeField]
    private float _progressTimerBase = 10;
    private float _progressTimer = 0;

    [Tooltip("Minimum amount of force applied")]
    [SerializeField]
    private float _fightingForceBase = 2;
    [Tooltip("This is the max amount of force that can pull away (+ or - this value)" +
        " Recommend having this less than player force.")]
    [SerializeField]
    private float _randomForceRange = 1;
    [SerializeField]
    private float _playerForce = 3.5f;
    [SerializeField]
    private float _randomForceTimer = 0;
    [SerializeField]
    private float _randomForceTimerBase = 2;
    [SerializeField]
    private float _randomForceDurationTimer = 0;
    [SerializeField]
    private float _randomForceDurationTimerBase = 1.5f;

    [SerializeField]
    private Vector3 _fightingForce = Vector3.zero;


    public override void Initialize(Transform location)
    {
        GameObject g = GameObject.Find("CastingHelper");
        //_helper = Instantiate(resources.castingPrefab, location.transform.position, location.transform.rotation, this.transform);
        _helper = Instantiate(g, location.transform.position, location.transform.rotation, this.transform);
        CastingComponentHolder c = _helper.GetComponent<CastingComponentHolder>();
        _fishingTarget = c.FishingTarget;
        _fishingProgress = c.FishingProgress;
        _launchArc = c.LaunchArc;
        _castingTarget = c.CastingTarget;

        _fishingProgress.SetActive(false);
        _launchArc.SetActive(false);
        _castingTarget.SetActive(false);


        _launchArc.transform.localScale = Vector3.zero;

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
                    Debug.Log("Going out");
                    _fishingTarget.transform.position += _fishingTarget.transform.forward * _initialCastingSpeed * Time.deltaTime;
                }
                if (Input.GetMouseButtonUp(0))
                {
                    _fishingProgress.SetActive(true);
                    _launchArc.SetActive(true);
                    _castingTarget.SetActive(true);

                    _randomForceTimer = _randomForceTimerBase;
                    _fightingForce = Vector3.zero;
                    _fishingProgress.transform.position = _fishingTarget.transform.position;
                    _fishingState = 2;
                    _progressTimer = 0;
                }
                return true;
                break;

            //chasing the target
            case 2:
                //moving the target sphere           

                _randomForceTimer -= Time.deltaTime;
                if (_randomForceTimer < 0)
                {
                    if (_fightingForce == Vector3.zero)
                    {
                        float r = 0;
                        r = Random.Range(-1, 1);
                        float x = (Random.Range(0, _randomForceRange) + _fightingForceBase) * r;
                        r = Random.Range(-1, 1);
                        float z = (Random.Range(0, _randomForceRange) + _fightingForceBase) * r;

                        _fightingForce = new Vector3(x, 0, z);
                    }
                    _randomForceDurationTimer -= Time.deltaTime;
                    _randomForceTimer = 0;
                    //_castingTarget.transform.position += _fightingForce * Time.deltaTime;

                    if (_randomForceDurationTimer <= 0)
                    {
                        _randomForceTimer = _randomForceTimerBase;
                        _randomForceDurationTimer = _randomForceDurationTimerBase;
                        _fightingForce = Vector3.zero;
                    }
                }

                //apply player controls
                Vector3 playerInputForce = Vector3.zero;
                if (Input.GetKey(KeyCode.W)) playerInputForce += _castingTarget.transform.forward;
                if (Input.GetKey(KeyCode.A)) playerInputForce += -_castingTarget.transform.right;
                if (Input.GetKey(KeyCode.S)) playerInputForce += -_castingTarget.transform.forward;
                if (Input.GetKey(KeyCode.D)) playerInputForce += _castingTarget.transform.right;

                playerInputForce *= _playerForce;
                playerInputForce += _fightingForce;

                _castingTarget.transform.position += playerInputForce * Time.deltaTime;

                //counting the time
                _progressTimer += Time.deltaTime;

                //scaling the arc
                float arcSize = _progressTimer / _progressTimerBase *_fishingTarget.transform.localPosition.z;
                _launchArc.transform.localScale = new Vector3(1, arcSize, arcSize);

                if (_progressTimer >= _progressTimerBase)
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

