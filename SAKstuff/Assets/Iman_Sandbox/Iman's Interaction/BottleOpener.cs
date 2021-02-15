﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleOpener : MonoBehaviour
{
    [HideInInspector]
    public bool bottleOpened = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BottleOpener")
        {
            this.GetComponent<Rigidbody>().isKinematic = false;
            this.GetComponent<BoxCollider>().isTrigger = false;
            if (this.GetComponent<Rigidbody>().useGravity == false)
            {
                this.GetComponent<Rigidbody>().useGravity = true;
            }
        }
    } 
}
