using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UseItemStateMachine : MonoBehaviour
{
    [SerializeField]
    private bool _isFishing = false;

    [SerializeField]
    private ToolComponentReferences references;

    [SerializeField]
    private Transform _fishingLocation;

    public ToolData Tool1;

    [SerializeField]
    private int _useItemState = 0;

    private ToolStateMachine _toolStateMachine = null;
    [SerializeField]
    private Component[] _baseList;

    [SerializeField]
    private Component[] _activeComponents;

    private void Start()
    {
        FishingEventsController.current.onStartFishing += FishingToggle;
        _baseList = GetComponents<Component>();
    }
    
    private void Update()
    {
        //whether or not the player is fishing
        if (_isFishing)
        {
            //we use this state machine to track the player's progress through the states of fishing
            switch (_useItemState)
            {
                case 1:
                    //detect what tool the player is using
                    //TODO: need some method of easy access to the player's 'inventory' or 'currently held tool'                 

                    //make sure the player has a valid tool equipped
                    if (Tool1.ToolType != fishEnums.ToolRequired.None || Tool1.ToolType != fishEnums.ToolRequired.Any)                        
                    {
                        //once we're done calculating what the player has, we move onto next state
                        _useItemState = 2;
                    }
                    else
                    {
                        Debug.LogError("ERROR: Player attempting to fish with improper tool equipped.");
                        Debug.LogError("Tool must not have 'any' or 'none' as it's type");
                        _useItemState = 0;
                    }
                    break;

                case 2:
                    //Have the tool create the appropriate state machine to handle that tool

                   _toolStateMachine= Tool1.CreateStateMachine(gameObject);

                    if (_toolStateMachine != null)
                    {
                        _toolStateMachine.Initialize(this, Tool1,_fishingLocation, references);
                        //change to state 3 to wait for the tool
                        _useItemState = 3;
                    }
                    else
                    {
                        Debug.LogError("ERROR: could not find valid script or tool");
                    }
                    break;

                case 3:
                    //wait for that tool to finish
                    _toolStateMachine.Execute();

                    break;
                case 4:
                    //once the tool is done, this is where the wrap up /follow up happens

                    //make sure we null out the reference
                    _toolStateMachine = null;
                    break;
            }

            //break out of fishing state
            if (_useItemState == 0)
            {
                //TODO: send event to cancel fishing / undo whatever was set by starting fishing
                _isFishing = false;
            }

        }
        else
        {
            _useItemState = 0;
        }
    }


    private void FishingToggle()
    {
        _isFishing = !_isFishing;
        if(_isFishing) _useItemState = 1;
        //TODO: delete added components when fishing is done
        if (!_isFishing)
        {
            _useItemState = 0;
            Purge();
        }
            
    }

    private void Purge()
    {
        _activeComponents = GetComponents<Component>();
        foreach(Component c in _activeComponents)
        {
            if (!_baseList.Contains(c))
            {
                Destroy(c);
            }
        }
    }
}
