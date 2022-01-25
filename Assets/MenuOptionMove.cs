using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOptionMove : MonoBehaviour
{
    Vector3 newTrans;
    Vector3 origTrans;

    public bool isUp = false;
    void Start()
    {
        origTrans = transform.position;

        newTrans = new Vector3(origTrans.x, origTrans.y - 1.8f, origTrans.z);
    }

    // Update is called once per frame
    void Update()
    {
        MoveMesh();
    }

    void MoveMesh()
    {
        Vector3 offset;

        if (!isUp)
        {
            offset = transform.position - newTrans;

            if(offset.magnitude >0.1f)
            {
                transform.position = Vector3.Lerp(transform.position, newTrans, Time.deltaTime * 4);
            }
        }

        else
        {
            offset = transform.position - origTrans;

            if (offset.magnitude > 0.1f)
            {
                transform.position = Vector3.Lerp(transform.position, origTrans, Time.deltaTime * 4);
            }
        }
    }
}
