using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
public class SlideCollisionSystem : MonoBehaviour
{

    [SerializeField] Player_ControllerV2 playerV2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PlayerUnit" )
        {

            if(!playerV2.isInSpline)
            {
                playerV2.StartFollow();


            }


        }
    }


    

}
