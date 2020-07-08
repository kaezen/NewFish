using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fishing Rod", menuName = "New Fishing Rod")]
public class ToolRodData : ToolData
{
    public ToolRodData()
    {
        ToolType = fishEnums.ToolRequired.Rod;
    }
}
