using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ToolStateMachine : MonoBehaviour
{
    [SerializeField]
    public UseItemStateMachine parentStateMachine;
    
    public ToolData PlayerTool
    {
        get { return _playerTool; }
        set { _playerTool = value; }
    }
    [SerializeField]
    private ToolData _playerTool;
    public abstract void Initialize(UseItemStateMachine parent, ToolData tool);

    //check the options the player has selected in his tool and generate components for that
    public abstract void CreateAssets();
}
