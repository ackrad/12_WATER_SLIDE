using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Controller : MonoBehaviour
{
    [SerializeField] float xClamp = 5f;
    [SerializeField] float yClamp = 1f;
    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update() // TODO make more readable
    {
        transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, -1 * xClamp, xClamp), Mathf.Clamp(transform.localPosition.y, -1 * yClamp, yClamp), 1.42f);


    }
}
