using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
public class SlideCollisionSystem : MonoBehaviour
{

    [SerializeField] Player_Movement playerV2;
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

            if(!collision.collider.gameObject.GetComponent<Player_Movement>().isInSpline)
            {
                playerV2.StartFollow();


            }


        }
    }


    

}
