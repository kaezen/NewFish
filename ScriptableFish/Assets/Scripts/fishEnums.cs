using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishEnums : MonoBehaviour
{
    public enum BodyOfWaterType { Any, Ocean, Lake, Pond, Stream};
    public enum TimeOfDay {  Any, Morning, Day, Evening, Night};
    public enum Attractant {  Any, Lure, Living };
    public enum ToolRequired {  Any, Rod, Spear};
    public enum CastingRange { Any, Close, Far };
    public enum EnticeMethod {  Any, Rhythmic, Random, Predictive };
    public enum RetrievalMethod { Any, Instant, Constant, OnOff };
}
