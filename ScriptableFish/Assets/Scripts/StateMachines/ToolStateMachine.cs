using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ToolStateMachine : MonoBehaviour
{
    public ToolComponentReferences References;

    [SerializeField]
    public UseItemStateMachine parentStateMachine;
    [SerializeField]
    public Transform _fishingLocation;
    public ToolData PlayerTool
    {
        get { return _playerTool; }
        set { _playerTool = value; }
    }
    [SerializeField]
    private ToolData _playerTool;

    public ToolComponentReferences toolReferences;
    public abstract void Initialize(UseItemStateMachine parent, ToolData tool, Transform location, ToolComponentReferences references);

    public abstract bool Execute();

    //check the options the player has selected in his tool and generate components for that
    public abstract void CreateAssets();
}
