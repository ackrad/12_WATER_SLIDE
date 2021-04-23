using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float mouseGap = 20f;
    [SerializeField] Transform parentGameObject;
    //[SerializeField] SplineComputer spComputer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() // TODO character positiona ihtiyacýn yok zaten karakter hep ekranýn ortasýnda.
    {


            Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 mousePos = Input.mousePosition;

        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -0.28f);

            if(screenPos.x+ mouseGap < mousePos.x)
            {
                transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.Self) ;


            }

        else if (screenPos.x - mouseGap > mousePos.x)
        {
                transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.Self);

            

            }

     
    


    }


    public void StopFollow()
    {
        parentGameObject.GetComponent<SplineFollower>().follow = false;


    }
}
