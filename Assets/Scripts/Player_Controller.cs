using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
using DG.Tweening;
using System;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float mouseGap = 20f;
    [SerializeField] float sideMoveSpeed = 5f;
    [SerializeField] float rotationSpeed = 2f;
    [SerializeField] float upForce = 10f;
    [SerializeField] float secondsToWait = 0.5f;
    [SerializeField] CinemachineSwitcher cinemachineSwitcher;

    [SerializeField] SplineComputer sp;
    [Header("TODO Bunu dynamic yap")]
    [SerializeField] float maxOfset = 3f;
    [SerializeField] string splineTag = "Spline";
    [SerializeField] Transform winPosition;

    // cached
    SplineFollower spFollower;
    Rigidbody rb;
    CapsuleCollider capsuleCollider;
    
    //booleans
    bool isMouseActive = false;
    bool isFollowing = true;
    public bool isPlayerActive = true;


    [Header("Ending Animation Metrics")]
    [SerializeField] private Ease moveEase = Ease.Linear;
    [SerializeField] float animMoveDuration=2f ;
    [SerializeField] Transform poolPosition;
    [SerializeField] float upMoveAmount = 7f;
    [SerializeField] PathType pathType;
    [SerializeField] PathMode pathMode;

    // Start is called before the first frame update
    void Start()
    {
        spFollower = GetComponent<SplineFollower>();
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();

    }

    // Update is called once per frame
    void Update()
    {



        if (isFollowing  && isPlayerActive)
        {
            
                SlidingMethod();
            CheckIfOutOfOffset();
          

        }

        if (sp.Project(transform.position).percent > 0.99 && isPlayerActive && isFollowing)
        {
            WinGame();
        }

        else
        {
            if (isPlayerActive)
            {
                FlyingMethod();
            }
        }


    }

    private void FlyingMethod()
    {

        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mousePos = Input.mousePosition;

        rb.velocity = new Vector3(0,rb.velocity.y,0) + transform.forward * moveSpeed; // y velocityi koruyup ileri doðru hýz vermek için


        if (screenPos.x + mouseGap < mousePos.x)
        {

            transform.Rotate(0, rotationSpeed* Time.deltaTime , 0, Space.Self);

        }

        else if (screenPos.x - mouseGap > mousePos.x)
        {

            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0, Space.Self);


        }

    }

    private void CheckIfOutOfOffset()
    {
        float currentOffset = spFollower.motion.offset.x;
        if(currentOffset > maxOfset || currentOffset < -maxOfset)
        {

            StartCoroutine(StopFollowingSpline());

        }
    }

    private IEnumerator StopFollowingSpline()
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        
        spFollower.follow = false;
        rb.isKinematic = false;
        rb.AddForce(transform.up * upForce, ForceMode.VelocityChange);



        // Make rigidbody unkinematic so you can apply upwards foce
        isFollowing = false;
        spFollower.motion.offset = new Vector2(0, 0);
        capsuleCollider.enabled = false;

        yield return new WaitForSeconds(secondsToWait);

        capsuleCollider.enabled = true;
    }

    private void ActivateDeactivateMouse()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            ChangeMouseMode();
        }

        
    }

    private void SlidingMethod()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mousePos = Input.mousePosition;


        float offsetX = spFollower.motion.offset.x;
        float newOffsetX;

        if (screenPos.x + mouseGap < mousePos.x)
        {
            newOffsetX = offsetX + sideMoveSpeed*Time.deltaTime;
            float newOffsetY = maxOfset * Mathf.Cos(newOffsetX / maxOfset);

            spFollower.motion.offset = new Vector2(newOffsetX, -newOffsetY);

        }

        else if (screenPos.x - mouseGap > mousePos.x)
        {

            newOffsetX = offsetX - sideMoveSpeed* Time.deltaTime;
            float newOffsetY = maxOfset * Mathf.Cos(newOffsetX / maxOfset);

            spFollower.motion.offset = new Vector2(newOffsetX, -newOffsetY);


        }




    }


    private void ChangeMouseMode()
    {

        if(isMouseActive)
        {

            isMouseActive = false;
        }

        else
        {
            isMouseActive = true;
        }



    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(splineTag) )
        {

            StartFollowing();
        }
    }

    private void StartFollowing()
    {
        rb.isKinematic = true;
        spFollower.Restart(sp.Project(transform.position).percent); //restarts following from projected point
        spFollower.follow = true;
        isFollowing = true;
        spFollower.motion.offset = new Vector2(0, -maxOfset);
    }



    public void WinGame()
    {
        ChangeToDiveCamera();
        float depthOfPool = 4f;


        spFollower.follow = false;
        isPlayerActive = false;
        Vector3[] path = new Vector3[3];

        

        path[0]=transform.position - (transform.position - poolPosition.position )/2 + new Vector3(0,upMoveAmount,0);
        path[1] = poolPosition.position;
        path[2] = poolPosition.position + new Vector3(0, depthOfPool, 0);

        transform.DOPath(path, animMoveDuration, pathType, pathMode,10,Color.red).OnComplete(() => { ChangeToWinCamera(); }); ;
         

    }

 

    private void ChangeToDiveCamera()
    {
        cinemachineSwitcher.SwitchToDiveCamera();


    }

    private void ChangeToWinCamera()
    {
        transform.position = winPosition.position;

        cinemachineSwitcher.SwitchToWinCamera();
    }
}
