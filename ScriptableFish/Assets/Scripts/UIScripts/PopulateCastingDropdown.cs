using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateCastingDropdown : MonoBehaviour
{
    private Dropdown Dropdown;
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
        Dropdown.ClearOptions();

        string[] names = Enum.GetNames(typeof(fishEnums.CastingRange));
        List<string> dropNames = new List<string>(names);


        Dropdown.AddOptions(dropNames);
    }
}