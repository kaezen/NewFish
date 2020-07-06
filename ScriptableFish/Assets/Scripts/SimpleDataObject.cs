using UnityEngine;

[CreateAssetMenu(fileName = "New SimpleDataObject", menuName = "Simple Data Object")]
public class SimpleDataObject : ScriptableObject 
{
	#region Properties
	public string CoolTextField { get { return _coolTextField; } } // NOTE: We can protect this data field by only allowing public access to read it but not change it:
	[SerializeField]
	private string _coolTextField = string.Empty;

	public int CoolIntField { get { return _coolIntField; } } // NOTE: We can protect this data field by only allowing public access to read it but not change it:
	[SerializeField]
	private int _coolIntField = 0;
	#endregion Properties (end)

	#region Initialization	
	public SimpleDataObject() 
	{
		
	}
	#endregion Initialization (end)
}
