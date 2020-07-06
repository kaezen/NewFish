using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New FishDataCollection", menuName = "Fish Data Collection")]
public class FishDataCollection : ScriptableObject
{
    public IReadOnlyCollection<FishData> fishList { get { return _fishList.AsReadOnly(); } }
    [SerializeField]
    private List<FishData> _fishList = new List<FishData>();

    public FishDataCollection()
    {

    }

#if UNITY_EDITOR
    public void SetDataObjectList(List<FishData> fishDataList)
    {
        _fishList = new List<FishData>(fishDataList);

        UnityEditor.EditorUtility.SetDirty(this);
    }

#endif

}
