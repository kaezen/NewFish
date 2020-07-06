using UnityEngine;
using System.Collections.Generic;
using System.Collections.ObjectModel;

[CreateAssetMenu(fileName = "New SimpleDataCollection", menuName = "Simple Data Collection")]
public class SimpleDataCollection : ScriptableObject
{
    #region Properties
    public ReadOnlyCollection<SimpleDataObject> SimpleDataObjects { get { return _simpleDataObjects.AsReadOnly(); } } // NOTE: We can protect this data field by only allowing public access to a read only collection:
    [SerializeField]
	private List<SimpleDataObject> _simpleDataObjects = new List<SimpleDataObject>();
	#endregion Properties (end)

	#region Initialization	
	public SimpleDataCollection () 
	{
		
	}
    #endregion Initialization (end)

    #region Editor Methods
#if UNITY_EDITOR // NOTE: because we are referencing UnityEditor.EditorUtility here, we need to wrap the method in the UNITY_EDITOR so we won't get compiler errors
    public void SetDataObjectList(List<SimpleDataObject> dataObjectList)
    {
        // Store this new list of objects:
        _simpleDataObjects = new List<SimpleDataObject>(dataObjectList);

        // Manually call SetDirty to tell Unity that this object was changed:
        UnityEditor.EditorUtility.SetDirty(this);
    }
#endif
    #endregion Editor Methods (end)
}
