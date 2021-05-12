using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_CollisionV2 : MonoBehaviour
{
    [SerializeField] float forceAmount=500f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerUnit"))
        {

            GetComponent<Player_ControllerV2>().StopFollow();
            
        }
    }
    


}
