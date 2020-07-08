using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseRodStateMachine : ToolStateMachine
{


    //TODO: Create reference to player's fishing rod
    public override void Initialize(UseItemStateMachine parent, ScriptableObject tool)
    {
        Debug.Log("Let's go!");
        parentStateMachine = parent;
        PlayerTool = tool;

        //check the options the player has selected in his tool
    }    

    // Update is called once per frame
    void Update()
    {
        
    }

}
