using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public GameObject storieObject;
  

    public float speed = 1f;
    public float distance = 1f;

    private Vector3 initialPosition1;
    private float targetY;

    private void Start()
    {
        initialPosition1 = storieObject.transform.position;
        targetY = initialPosition1.y + distance;
    }

    private void Update()
    {
        float step = speed * Time.deltaTime;

        storieObject.transform.position = Vector3.MoveTowards(storieObject.transform.position, new Vector3(initialPosition1.x, targetY, initialPosition1.z), step);
    }
}
