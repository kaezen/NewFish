using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ToolStateMachine : MonoBehaviour
{
    [SerializeField]
    public UseItemStateMachine parentStateMachine;
    
    public ScriptableObject PlayerTool
    {
        get { return _playerTool; }
        set { _playerTool = value; }
    }
    [SerializeField]
    private ScriptableObject _playerTool;
    public abstract void Initialize(UseItemStateMachine parent, ScriptableObject tool);
}
