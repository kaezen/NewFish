using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItemStateMachine : MonoBehaviour
{
    [SerializeField]
    private bool _isFishing = false;

    [SerializeField]
    private fishEnums.ToolRequired _playerTool = fishEnums.ToolRequired.None;
    private ScriptableObject _playerTool2;


    public ToolData tool1;
    public ToolStateMachine Tool1StateMachine;    


    private int _fishingState = 0;
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
                    //create appropriate script/behavior to handle that tool

                    ToolStateMachine u = null;
                    
                    if (_playerTool == fishEnums.ToolRequired.Rod)
                    {
                        u = gameObject.AddComponent<UseRodStateMachine>();                        
                    }
                    if(_playerTool == typeof(ToolRodData))
                    
                    if (u != null)
                    {
                        u.Initialize(this, _playerTool2);
                        _fishingState = 3;                        
                    }
                    else
                    {
                        Debug.LogError("ERROR: could not find valid script or tool");
                    }
                    //if(_playerTool2 = tool1)
                    //{
                    //   gameObject.AddComponent(typeof(MonoBehaviour);
                    //}

                    break;

                case 3:
                    //wait for that tool to finish

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
