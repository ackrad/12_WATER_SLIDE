using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
public class SlideCollisionSystem : MonoBehaviour
{

    [SerializeField] 
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

            if(!collision.gameObject.GetComponent<Player_Movement>().isInSpline)
            {
                collision.gameObject.GetComponent<Player_Movement>().StartFollow();


            }


        }
    }


    

}
