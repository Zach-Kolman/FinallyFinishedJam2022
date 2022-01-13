using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanFade : MonoBehaviour
{
    public Animator screenAnim;
    public Transform entryPoint;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            screenAnim.SetBool("canFadeOut", true);
            other.GetComponent<PlayerController>().enterPoint = entryPoint;
            other.GetComponent<PlayerController>().StartCoroutine("MoveToNext");
        }
    }
}