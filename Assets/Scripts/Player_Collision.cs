using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Collision : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision) // TODO Geri d��erken collide etmeme izin verme. Spline ile collide etti�imde follou tekrar ba�lat
    {

        if (collision.gameObject.tag == "PlayerUnit")
        {
            GetComponentInChildren<Rigidbody>().AddRelativeForce(new Vector3(0f, 500f, 0f));
            collision.gameObject.GetComponent<Player_Movement>().StopFollow();

        }
    }
}
