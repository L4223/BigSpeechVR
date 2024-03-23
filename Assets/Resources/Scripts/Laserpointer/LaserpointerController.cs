using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserpointerController : MonoBehaviour
{
    
    private LineRenderer lr { set; get; }
    public Transform controller = null;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }


    void Update()
    {
        lr.SetPosition(0, controller.position);
        lr.SetPosition(1, controller.forward * 1000);
        RaycastHit hit;
        if (Physics.Raycast(controller.position, controller.forward * 1000 , out hit))
        {
            if (hit.collider)
            {
                lr.SetPosition(1, hit.point);
            }
        }
    }

}
