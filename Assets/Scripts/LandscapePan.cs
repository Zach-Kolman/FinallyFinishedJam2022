using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandscapePan : MonoBehaviour
{

    public float moveAmount;

    public float jumpAmount;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);

        if(transform.position.z <= -moveAmount)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + jumpAmount);
        }
    }
}
