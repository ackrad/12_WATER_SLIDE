using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Collision : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision) // TODO Geri düþerken collide etmeme izin verme. Spline ile collide ettiðimde follou tekrar baþlat
    {

        if (collision.gameObject.tag == "PlayerUnit")
        {
            GetComponentInChildren<Rigidbody>().AddRelativeForce(new Vector3(0f, 500f, 0f));
            collision.gameObject.GetComponent<Player_Movement>().StopFollow();

        }
    }
}
