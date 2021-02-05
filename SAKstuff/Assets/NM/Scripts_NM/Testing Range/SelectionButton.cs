﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;

/// <summary>
/// P3 Swiss Army Knife project
/// Namgar Mardvaeva
/// Group № 2 (Iman, Namgar, Torben)
/// Summary: 
/// 1) Responsible for giving signal that trigger from left controller was pressed for starting selection mode
/// 2) Has to be connceted with appropriate Button (trigger on left VR controller)
/// 3) Part of the observer pattern.
/// </summary>

public class SelectionButton : MonoBehaviour
{
    public SteamVR_Action_Boolean selectionMode;
    public UnityEvent selectedIcon;
    private bool touched = false;
    private string toolName;

    // Connected with script reactable icon: if pointer touches/hovering above icon - this method is activated (look on update)
    public void TouchedIcon(string tN)
    {
        toolName = tN;
        Debug.Log("tN:" + tN);
        touched = true;
    }

    // Update is called once per frame
    void Update()
    {
        // If trigger was pressed and the pointer is hovering above, the icon is selected
        if (selectionMode.stateDown == true && touched == true) // works with clicking
        {
            selectedIcon.Transferred(toolName);
            Debug.Log("toolName:" + toolName);
            selectedIcon.Occured();
        }
    }
}
