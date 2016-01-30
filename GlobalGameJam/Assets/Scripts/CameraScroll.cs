using UnityEngine;
using System.Collections;

public class CameraScroll : MonoBehaviour {

    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;
    public GameObject blockRight;
    public GameObject blockLeft;

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            
            GetComponent<Camera>().orthographicSize = 5.5f;
            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
            Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.3f, 0.3f, 10)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
            if (Vector3.Distance(transform.position, blockRight.transform.position) < 19)
            {
                    transform.position = new Vector3(4.0f, transform.position.y, transform.position.z);
            }

            if (Vector3.Distance(transform.position, blockLeft.transform.position) < 19)
            {
                transform.position = new Vector3(-4.1f, transform.position.y, transform.position.z);
            }     
        }

    }
}
