using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
using System;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float mouseGap = 20f;
    [SerializeField] float sideMoveSpeed = 5f;
    [SerializeField] float rotationSpeed = 2f;

    [SerializeField] SplineComputer sp;
    [Header("TODO Bunu dynamic yap")]
    [SerializeField] float maxOfset = 3f;

    SplineFollower spFollower;

    bool isMouseActive = false;
    bool isFollowing = true;
    



    // Start is called before the first frame update
    void Start()
    {
        spFollower = GetComponent<SplineFollower>();


    }

    // Update is called once per frame
    void Update()
    {
        ActivateDeactivateMouse();
        if (isMouseActive )
        {
            if (isFollowing)
            {
                MoveMethod();
            }
        }


        if (!isFollowing)
        {

            MoveMethod2();
        }

        CheckIfOutOfOffset();
    }

    private void MoveMethod2()
    {

        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mousePos = Input.mousePosition;


        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.Self);

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

            StopFollowingSpline();

        }
    }

    private void StopFollowingSpline()
    {
        isFollowing = false;
        spFollower.enabled = false;

    }

    private void ActivateDeactivateMouse()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            ChangeMouseMode();
        }

        
    }

    private void MoveMethod()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mousePos = Input.mousePosition;




        if (screenPos.x + mouseGap < mousePos.x)
        {
            spFollower.motion.offset = new Vector2(spFollower.motion.offset.x + sideMoveSpeed*Time.deltaTime,0);

        }

        else if (screenPos.x - mouseGap > mousePos.x)
        {

            spFollower.motion.offset = new Vector2(spFollower.motion.offset.x - sideMoveSpeed * Time.deltaTime, 0);


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

}
