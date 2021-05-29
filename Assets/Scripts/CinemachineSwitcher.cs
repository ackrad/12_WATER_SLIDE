using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineSwitcher : MonoBehaviour
{

    [SerializeField] Cinemachine.CinemachineVirtualCamera slideCam;
    [SerializeField] Cinemachine.CinemachineVirtualCamera diveCam;
    [SerializeField] Cinemachine.CinemachineVirtualCamera winCam;


    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchToWinCamera()
    {
        winCam.Priority = diveCam.Priority + 1;

    }
    public void SwitchToDiveCamera()
    {
        diveCam.Priority = slideCam.Priority + 1;

    }
}
