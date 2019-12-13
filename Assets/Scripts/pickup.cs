using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class pickup : MonoBehaviour
{
    bool canPickup = false;
    public Transform theDest;
    public int y = 0;
    //int x = 0;
    public float scrollSpeed = 10;
    void OnMouseDown()
    {

        canPickup = true;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = theDest.position;
        this.transform.parent = GameObject.Find("Destination").transform;
        y = 1;

    }
    void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<BoxCollider>().enabled = true;
        canPickup = false;
        y = 0;
    }
    //private void FixedUpdate()
    //{

    //    Vector3 vect = Input.mouseScrollDelta;
    //    Quaternion x = new Quaternion(0, 0, 0, 0);
    //    Vector3 player = GameObject.Find("Destination").transform.position;
    //    Debug.Log(vect);
    //    Debug.Log(player);
    //    this.transform.SetPositionAndRotation(player + vect, x);
    //}

    void Update()
    {
        // x = GameObject.Find("Rubber Block (54)").GetComponent<pickup>().y;
        //Debug.Log(x);
        if (canPickup == true)
        {
            Vector3 vect = Input.mouseScrollDelta;
            vect.z = vect.y * scrollSpeed;
            vect.y = 0;
            Quaternion Q = new Quaternion(0, 0, 0, 0);
            Vector3 player = GameObject.Find("Destination").transform.position;
            this.transform.SetPositionAndRotation(player + vect, Q);
        }
        else
        {

        }


    }
}
