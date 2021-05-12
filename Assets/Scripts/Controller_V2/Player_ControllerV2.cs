using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class Player_ControllerV2 : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float mouseGap = 20f;
    [SerializeField] SplineComputer sp;
    [SerializeField] GameObject childGameObject;
    // Start is called before the first frame update



    public bool isInSpline = true;
    SplineFollower follower;
    void Start()
    {
        follower = gameObject.AddComponent<SplineFollower>(); //Create a follower
        follower.spline = sp;
        follower.followSpeed = 5f; //Set the speed of the follower
        follower.wrapMode = SplineFollower.Wrap.Default; //Set the wrap mode of the
        follower.autoStartPosition = true;
        follower.follow = true;
      

    }

    // Update is called once per frame
    void Update()
    {
        if (isInSpline)
        {
            MoveMethod();
        }

        FollowPath();

    }

    private void FollowPath()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {

            GetComponent<Rigidbody>().velocity = new Vector3(0f, 2f, 0f);
        
        }

        else if (Input.GetKeyDown(KeyCode.L))
        {
          


        }

        else if (Input.GetKeyDown(KeyCode.J))
        {

            follower.Move(5f);
        }

    }

    private void MoveMethod()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mousePos = Input.mousePosition;




        if (screenPos.x + mouseGap < mousePos.x)
        {
           childGameObject.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.Self);


        }

        else if (screenPos.x - mouseGap > mousePos.x)
        {
            childGameObject.transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.Self);



        }

    }



    public void StartFollow()
    {
        follower.Restart(sp.Project(transform.position).percent); //restarts following from projected point
        follower.follow = true;
        isInSpline = true;


    }

    public void StopFollow()
    {

        follower.follow = false;
        isInSpline = false;

       



    }

}
