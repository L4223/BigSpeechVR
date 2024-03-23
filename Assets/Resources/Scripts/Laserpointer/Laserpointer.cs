using UnityEngine;


public class Laserpointer : MonoBehaviour
{
    private LineRenderer lr { set; get; }

    public Transform fingerTip = null;
    public Transform fingerWrist = null;

    private Vector3 _fingerTipPosition;
    private Vector3 _fingerWristPosition;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        // _startPointPosition = startPoint.position;
        // lr.SetPosition(1, _startPointPosition);
    }

    // Update is called once per frame
    void Update()
    {
        _fingerTipPosition = fingerTip.position;
        _fingerWristPosition = fingerWrist.position;
        Vector3 direction = (_fingerWristPosition - _fingerTipPosition).normalized;
        lr.SetPosition(0, _fingerTipPosition);
        lr.SetPosition(1, _fingerTipPosition - direction * 1000);
        RaycastHit hit;
        if (Physics.Raycast(_fingerTipPosition, -direction, out hit))
        {
            if (hit.collider)
            {
                lr.SetPosition(1, hit.point);
            }
        }
        // else lr.SetPosition(1, startPoint.forward * 1000);
    }
}