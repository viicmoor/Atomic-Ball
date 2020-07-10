using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] GameObject ballMesh;
    public float speed = 0.01f;
    float count;
    [SerializeField] float angle;
    float rotationAngle;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitForward;
        Physics.Raycast(transform.position, transform.forward, out hitForward, 3.0f, 1 << LayerMask.NameToLayer("Walls"));


        if (hitForward.collider) Debug.DrawRay(transform.position, transform.forward * hitForward.distance, Color.red);
        else Debug.DrawRay(transform.position, transform.forward * 3.0f, Color.green);


        transform.Rotate(0, rotationAngle, 0);
        if(!hitForward.collider)
        {
            Vector3 pos = transform.position;
            pos.z += transform.forward.z * speed;
            pos.x += transform.forward.x * speed;
            transform.position = pos;
            ballMesh.transform.Rotate(0, 0, speed);
        }
        
        if (count < 1.0f)
        {
            count += Time.deltaTime;           
        }
        else 
        {
            count = 0;
            rotationAngle = UnityEngine.Random.Range(-angle, angle);         
        }
    }
}
