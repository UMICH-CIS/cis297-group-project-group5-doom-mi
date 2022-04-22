using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunrotation : MonoBehaviour
{
    public Camera cam; 
    // Start is called before the first frame update
    private void FixedUpdate()
    {

        Vector3 v = cam.ScreenToWorldPoint(Input.mousePosition);
        v -= transform.position;
        v.z = 0;
        transform.up = v;
    }

}
