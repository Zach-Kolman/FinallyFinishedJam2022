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
    public float speed;
    private float baseSpeed;

    public CinemachineVirtualCamera curCam;

    public GameObject CM;

    public Transform cmt;
    public Transform enterPoint;
    public Transform exitPoint;


    public bool controlsEnabled;
    public bool canEnter = false;
    public bool canExit = false;
    private bool crouching = false;

    public Vector3 offset;

    private Animator animator;

    public AudioClip footstep1;
    public AudioClip footstep2;
    private AudioSource source;

    private Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        
        baseSpeed = speed;
        source = transform.GetChild(0).GetComponent<AudioSource>();
        cont = gameObject.GetComponent<CharacterController>();
        animator = transform.GetChild(0).GetComponent<Animator>();
        cmt = null;
    }

    // Update is called once per frame
    void Update()
    {
        ray = new Ray(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), transform.up);
        Debug.DrawRay(ray.origin, ray.direction * 2);

        if (controlsEnabled)
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

        if(Input.GetButtonDown("Crouch"))
        {
            if(!crouching)
            {
                crouching = !crouching;
                speed = speed / 2;
                source.volume = 0.15f;
                cont.height /= 2;
                cont.center = new Vector3(cont.center.x, cont.center.y - 0.505f, cont.center.z);
            }

            else
            {
                RaycastHit hit;
                if (Physics.Raycast(ray, 2))
                {
                    
                    print("boob");
                    
                }

                else
                {
                    crouching = !crouching;
                    speed = baseSpeed;
                    source.volume = 0.5f;
                    cont.height *= 2;
                    cont.center = new Vector3(cont.center.x, cont.center.y + 0.505f, cont.center.z);
                }
            }
        }

        animator.SetBool("IsCrouching", crouching);

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
