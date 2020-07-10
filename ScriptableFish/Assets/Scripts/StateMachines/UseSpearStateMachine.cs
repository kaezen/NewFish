using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSpearStateMachine : ToolStateMachine
{

    //TODO: Create reference to player's fishing spear
    public override void Initialize(UseItemStateMachine parent, ToolData tool)
    {
        Debug.Log("Let's go!");
        parentStateMachine = parent;
        PlayerTool = tool;

        CreateAssets();
    }
        //check the options the player has selected in his tool
    public override void CreateAssets()
    {
        
    }


    // Update is called once per frame
    void Update()
    {

    }

}
