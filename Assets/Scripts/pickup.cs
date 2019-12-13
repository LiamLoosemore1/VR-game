using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class pickup : MonoBehaviour
{
    bool canPickup = false;
    public Transform theDest;
    //int x = 0;
    public float scrollSpeed = 10;
    void OnMouseDown()
    {

        canPickup = true;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = theDest.position;
        this.transform.parent = GameObject.Find("Destination").transform;

    }
    void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<BoxCollider>().enabled = true;
        canPickup = false;
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
        
        if (canPickup == true)
        {

            Vector3 vect = Input.mouseScrollDelta;
            Debug.Log("first" + vect);
            vect.z = vect.y * scrollSpeed;
            vect.y = 0;
            Debug.Log(vect);
            Quaternion Q = new Quaternion(0, 0, 0, 0);
            Vector3 destinationPosition = GameObject.Find("Destination").transform.position;
            Vector3 newPosition = new Vector3(destinationPosition.x, destinationPosition.y, vect.z);
            Vector3 localPosition = theDest.InverseTransformPoint(newPosition);
            this.transform.SetPositionAndRotation(localPosition, Q);

        }
        else
        {

        }


    }

    private Vector3 InverseTransformPoint(object Destination)
    {
        throw new NotImplementedException();
    }
}
