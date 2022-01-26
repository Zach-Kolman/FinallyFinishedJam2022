using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    private CharacterController cont;
    public float pAngle;

    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;

    public CinemachineVirtualCamera curCam;

    public GameObject CM;
    public Transform cmt;

    public float speed;

    public bool controlsEnabled;

    public Transform enterPoint;
    public Transform exitPoint;

    public bool canEnter = false;
    public bool canExit = false;

    public Vector3 offset;

    private Animator animator;

    public AudioClip footstep1;
    public AudioClip footstep2;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        cont = gameObject.GetComponent<CharacterController>();
        animator = transform.GetChild(0).GetComponent<Animator>();
        cmt = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(controlsEnabled)
        {
            MovePlayer();
        }

        if (canEnter)
        {
            MoveToCar();
        }

        if(canExit)
        {
            LeaveCar();
        }

        curCam = CM.GetComponent<CamManager>().curCam;

        cmt = curCam.transform;

        Fall();
    }

    private void Fall()
    {
        Vector3 velocity = Vector3.up * -10;

        if (!cont.isGrounded)
        {
            cont.Move(velocity * Time.deltaTime);
        }
    }

    private void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.z);



        if (direction.magnitude >= 0.1f)
        {
            float tragetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cmt.eulerAngles.y;
            pAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, tragetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, pAngle, 0);
            Vector3 moveDir = Quaternion.Euler(0f, tragetAngle, 0f) * Vector3.forward;

            cont.Move(moveDir.normalized * Time.deltaTime * speed);
        }

    }

    public IEnumerator SetEnter()
    {
        yield return new WaitForSeconds(2);
        canEnter = true;
    }

    public IEnumerator MoveToNext()
    {
        
        
        yield return new WaitForSeconds(2);
        transform.position = enterPoint.position;
        canExit = false;

    }

    public void MoveToCar()
    {
        offset = enterPoint.position - transform.position;

        if(offset.magnitude > .2f)
        {
            offset = offset.normalized * speed;
            cont.Move(offset * Time.deltaTime);
        }

        else
        {
            canEnter = false;
            controlsEnabled = true;
        }
    }

    public void LeaveCar()
    {
        
        offset = exitPoint.position - transform.position;
        controlsEnabled = false;

        if (offset.magnitude > .2f)
        {
            offset = offset.normalized * speed;
            cont.Move(offset * Time.deltaTime);
        }

    }

}
