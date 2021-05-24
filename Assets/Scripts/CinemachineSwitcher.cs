using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineSwitcher : MonoBehaviour
{

    private Animator animator;
    private string slideModAnimation = "SlideMod";
    private string winCameraAnimation = "WinCamera";
    private string diveCameraAnimation = "DiveMod";

    private void Awake()
    {
        animator = GetComponent<Animator>();
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
        animator.Play(winCameraAnimation);

    }
    public void SwitchToDiveCamera()
    {
        animator.Play(diveCameraAnimation);

    }
}
