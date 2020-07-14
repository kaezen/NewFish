using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingStateMachine : MonoBehaviour
{
    //TODO: functionality... starting with initial idea for casting

    [SerializeField]
    private CastingStateMachineResources resources;

    private GameObject _helper;

    [SerializeField]
    private GameObject _fishingTarget;
    [SerializeField]
    private GameObject _fishingProgress;
    [SerializeField]
    private GameObject _launchArc;

    [SerializeField]
    private int _fishingState = 0;

    //TODO: Replace this when get scriptable object reference working
    [SerializeField]
    private float speed = 2;

    public void Initialize(Transform location)
    {
        GameObject g = GameObject.Find("CastingHelper");
        //_helper = Instantiate(resources.castingPrefab, location.transform.position, location.transform.rotation, this.transform);
        _helper = Instantiate(g, location.transform.position, location.transform.rotation, this.transform);
        CastingComponentHolder c = _helper.GetComponent<CastingComponentHolder>();
        _fishingTarget = c.FishingTarget;
        _fishingProgress = c.FishingProgress;
        _launchArc = c.LaunchArc;

        _fishingState = 1;        
    }

    public bool Execute()
    {
        switch (_fishingState)
        {
            //going out / targeting
            case 1:                
                if (Input.GetMouseButton(0))
                {
                    Debug.Log("Going out");
                    _fishingTarget.transform.position += _fishingTarget.transform.forward * speed * Time.deltaTime;
                    return true;
                }
                break;

                //chasing the target
            case 2:
                break;
            case 3:
                break;
        }
        return false;
    }
}
