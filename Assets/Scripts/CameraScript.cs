using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] Transform player;

    Player_Controller playerController;

    bool isPlayerFollowingSpline = true;
    // Start is called before the first frame update
    void Start()
    {

        playerController = player.GetComponent<Player_Controller>();

    }

    // Update is called once per frame
    void Update()
    {

        if (isPlayerFollowingSpline)
        {
            transform.LookAt(player);

            float currentOffsetPlayer = playerController.ReturnCurrentOffset();

            transform.localPosition = new Vector3(-currentOffsetPlayer, transform.localPosition.y, transform.localPosition.z);


        }



    }
}
