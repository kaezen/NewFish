using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PopulateBodyOfWaterDropdown : MonoBehaviour
{
    public Dropdown Dropdown;
    // Start is called before the first frame update

    private void Start()
    {
        UpdateDropdownValues();
    }

    private void OnValidate()
    {
        if (Dropdown == null) Dropdown = GetComponent<Dropdown>();
        UpdateDropdownValues();
    }
    private void UpdateDropdownValues()
    {
        string[] names = Enum.GetNames(typeof(fishEnums.BodyOfWaterType));
        List<string> dropNames = new List<string>(names);

        Dropdown.ClearOptions();

        Dropdown.AddOptions(dropNames);
    }
}
