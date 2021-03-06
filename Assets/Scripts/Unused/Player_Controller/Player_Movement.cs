using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float mouseGap = 20f;
    [SerializeField] Transform parentGameObject;
    [SerializeField] SplineComputer spComp;

    public bool isInSpline = true;
    SplineFollower sp;

    //[SerializeField] SplineComputer spComputer;
    // Start is called before the first frame update
    void Start()
    {
        sp = parentGameObject.GetComponent<SplineFollower>();
    }

    // Update is called once per frame
    void Update() // TODO character positiona ihtiyac?n yok zaten karakter hep ekran?n ortas?nda.
    {

        if (isInSpline)
        {
            MoveMethod();
        }

    
    }

    private void MoveMethod()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mousePos = Input.mousePosition;
      


            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -0.28f);
        
            if (screenPos.x + mouseGap < mousePos.x)
            {
                transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.Self);


            }

            else if (screenPos.x - mouseGap > mousePos.x)
            {
                transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.Self);



            }
        
    }

    public void StopFollow()
    {

        parentGameObject.GetComponent<SplineFollower>().follow = false;
        changeisInSplineBool(false);

    }


    public void changeisInSplineBool(bool value)
    {

        isInSpline = value;

    }


    public void StartFollow()
    {

    
        parentGameObject.position = transform.position;
        transform.localPosition = new Vector3(0f, 0f, 0f);

        sp.Restart(spComp.Project(transform.position).percent);
        sp.follow = true;

        changeisInSplineBool(true);
    }
}
