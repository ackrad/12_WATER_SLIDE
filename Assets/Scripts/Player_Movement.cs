using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

     //   if (Input.GetKeyDown(KeyCode.Space))
       // {

            Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 mousePos = Input.mousePosition;
          //  Debug.Log("Object Position =" + screenPos);
           // Debug.Log("Mouse Position =" + Input.mousePosition);

            if(screenPos.x < mousePos.x)
            {
                transform.Translate(Vector3.right * Time.deltaTime*moveSpeed, Space.Self) ;


            }

            else
            {
                transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.Self);

            }

       // }

    }
}
