using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public Transform destination;

    void OnMouseDown()
    {
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = destination.position;

        this.transform.parent = GameObject.Find("HeldItem").transform;
    }

    void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
    }

}
