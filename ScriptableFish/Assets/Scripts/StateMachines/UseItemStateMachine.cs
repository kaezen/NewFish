using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItemStateMachine : MonoBehaviour
{
    [SerializeField]
    private bool _isFishing = false;

    [SerializeField]
    private fishEnums.ToolRequired _playerTool = fishEnums.ToolRequired.None;



    public ToolData Tool1;


    private int _fishingState = 0;

    private ToolStateMachine _toolStateMachine = null;
    private void Start()
    {
        FishingEventsController.current.onStartFishing += OnStartFishing;
    }

    private void Update()
    {
        //whether or not the player is fishing
        if (_isFishing)
        {
            //we use this state machine to track the player's progress through the states of fishing
            switch (_fishingState)
            {
                case 1:
                    //detect what tool the player is using
                    //TODO: need some method of easy access to the player's 'inventory' or 'currently held tool'

                    //for now, we're just going to assign it
                    _playerTool = fishEnums.ToolRequired.Rod;

                    //make sure the player has a valid tool equipped
                    if (_playerTool != fishEnums.ToolRequired.None || _playerTool != fishEnums.ToolRequired.Any)
                    {
                        //once we're done calculating what the player has, we move onto next state
                        _fishingState = 2;
                    }
                    else
                    {
                        Debug.LogError("ERROR: Player attempting to fish with improper tool equipped.");
                        Debug.LogError("Tool must not have 'any' or 'none' as it's type");
                        _fishingState = 0;
                    }
                    break;

                case 2:
                    //Have the tool create the appropriate state machine to handle that tool

                   _toolStateMachine= Tool1.CreateStateMachine(gameObject);

                    //if(_playerTool == typeof(ToolRodData))

                    if (_toolStateMachine != null)
                    {
                        _toolStateMachine.Initialize(this, Tool1);
                        //change to state 3 to wait for the tool
                        _fishingState = 3;
                    }
                    else
                    {
                        Debug.LogError("ERROR: could not find valid script or tool");
                    }
                    break;

                case 3:
                    //wait for that tool to finish

                    break;
                case 4:
                    //once the tool is done, this is where the wrap up /follow up happens

                    //make sure we null out the reference
                    _toolStateMachine = null;
                    break;
            }

            //break out of fishing state
            if (_fishingState == 0)
            {
                //TODO: send event to cancel fishing / undo whatever was set by starting fishing
                _isFishing = false;
            }

        }
        else
        {
            _fishingState = 0;
        }
    }


    private void OnStartFishing()
    {
        _isFishing = true;
        _fishingState = 1;
    }
}
