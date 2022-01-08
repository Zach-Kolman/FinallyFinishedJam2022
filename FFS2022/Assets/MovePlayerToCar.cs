using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerToCar : MonoBehaviour
{
    public Transform entryPoint;
    public Animator screenAnim;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            screenAnim.SetBool("canFadeOut", false);
            other.GetComponent<PlayerController>().enterPoint = entryPoint;
            other.GetComponent<PlayerController>().StartCoroutine("SetEnter");
        }
    }
}
