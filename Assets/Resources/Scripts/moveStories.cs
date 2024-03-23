using UnityEngine;

public class MoveObjectsUp : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;

    public float speed = 1f;
    public float distance = 1f;

    private Vector3 initialPosition1;
    private Vector3 initialPosition2;
    private float targetY;

    private void Start()
    {
        initialPosition1 = object1.transform.position;
        initialPosition2 = object2.transform.position;

        targetY = initialPosition1.y + distance;
    }

    private void Update()
    {
        float step = speed * Time.deltaTime;

        object1.transform.position = Vector3.MoveTowards(object1.transform.position, new Vector3(initialPosition1.x, targetY, initialPosition1.z), step);
        object2.transform.position = Vector3.MoveTowards(object2.transform.position, new Vector3(initialPosition2.x, targetY, initialPosition2.z), step);
    }
}
