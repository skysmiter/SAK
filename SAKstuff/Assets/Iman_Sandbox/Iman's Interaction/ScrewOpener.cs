﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewOpener : MonoBehaviour
{
    public float rotationSpeed = 150f;
    public float moveSpeed = 1f;
    public bool touched;
    public Vector3 endPos = new Vector3(0.232f, 5f, 0f);

    private string sakTag = "ScrewDriver";

    // For adventure
    [HideInInspector]
    public bool screwOpened = false;

    void Start()
    {
        GetComponent<Rigidbody>().isKinematic = true;
    }

    public void OnTriggerEnter (Collider collision)
    {
        if(collision.transform.CompareTag(sakTag))
        {
            //FindObjectOfType<AudioManager>().Play("balloon");
            touched = true;
            FindObjectOfType<WoodenPlank>().amount -= 1;
        }
    }

    private void Update()
    {
        if (transform.position.x >= endPos.x)
        {
            dropDown();
        }
        if (touched)
        {
            transform.eulerAngles += new Vector3(0f, 0f, -(rotationSpeed * Time.deltaTime));
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
    }
    void dropDown()
    {
        touched = false;
        GetComponent<Collider>().isTrigger = false;
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
