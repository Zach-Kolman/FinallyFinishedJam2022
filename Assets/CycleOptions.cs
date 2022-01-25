using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleOptions : MonoBehaviour
{
    public float optionID = 0;

    // Update is called once per frame
    void Update()
    {

        CycleMeshes();

        switch (optionID)
        {
            case 0:
                transform.GetChild(0).GetComponent<MenuOptionMove>().isUp = true;
                transform.GetChild(1).GetComponent<MenuOptionMove>().isUp = false;
                transform.GetChild(2).GetComponent<MenuOptionMove>().isUp = false;
                transform.GetChild(3).GetComponent<MenuOptionMove>().isUp = false;
                break;
            case 1:
                transform.GetChild(0).GetComponent<MenuOptionMove>().isUp = false;
                transform.GetChild(1).GetComponent<MenuOptionMove>().isUp = true;
                transform.GetChild(2).GetComponent<MenuOptionMove>().isUp = false;
                transform.GetChild(3).GetComponent<MenuOptionMove>().isUp = false;
                break;
            case 2:
                transform.GetChild(0).GetComponent<MenuOptionMove>().isUp = false;
                transform.GetChild(1).GetComponent<MenuOptionMove>().isUp = false;
                transform.GetChild(2).GetComponent<MenuOptionMove>().isUp = true;
                transform.GetChild(3).GetComponent<MenuOptionMove>().isUp = false;
                break;
            case 3:
                transform.GetChild(0).GetComponent<MenuOptionMove>().isUp = false;
                transform.GetChild(1).GetComponent<MenuOptionMove>().isUp = false;
                transform.GetChild(2).GetComponent<MenuOptionMove>().isUp = false;
                transform.GetChild(3).GetComponent<MenuOptionMove>().isUp = true;
                break;

        }
    }

    void CycleMeshes()
    {
        if(Input.GetKeyDown("w"))
        {
            if(optionID >= 3)
            {
                optionID = 0;
            }

            else
            {
                optionID++;
            }
        }

        if (Input.GetKeyDown("s"))
        {
            if(optionID <= 0)
            {
                optionID = 3;
            }

            else
            {
                optionID--;
            }
        }
    }
}
