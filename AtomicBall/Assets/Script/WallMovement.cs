using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    [SerializeField] KeyCode Up;
    [SerializeField] KeyCode Down;
    [SerializeField] KeyCode Right;
    [SerializeField] KeyCode Left;
    [SerializeField] float speed;
    [SerializeField] int orientation;
    
    
    void Update()
    {
        
        if (Time.deltaTime > 0)
        {
            if (Input.GetKey(Up))
            {
                RaycastHit ray;

                if (orientation == 1) Physics.Raycast(transform.position, transform.forward, out ray, 1.0f, 1 << LayerMask.NameToLayer("Walls"));               
                else Physics.Raycast(transform.position, -transform.right, out ray, 2.5f, 1 << LayerMask.NameToLayer("Walls"));                
                
                if (!ray.collider)
                {
                    Vector3 pos = transform.position;
                    pos.z += speed;
                    transform.position = pos;
                    if (orientation == 1) Debug.DrawRay(transform.position, transform.forward * 1.0f, Color.green);
                    else Debug.DrawRay(transform.position, -transform.right * 2.5f, Color.green);
                }
                else if (orientation == 1) Debug.DrawRay(transform.position, transform.forward * ray.distance, Color.red);
                else Debug.DrawRay(transform.position, -transform.right * ray.distance, Color.red);
            }
            else if (Input.GetKey(Down))
            {
                RaycastHit ray;
                if (orientation == 1) Physics.Raycast(transform.position, -transform.forward, out ray, 1.0f, 1 << LayerMask.NameToLayer("Walls"));
                else Physics.Raycast(transform.position, transform.right, out ray, 2.5f, 1 << LayerMask.NameToLayer("Walls"));

                if (!ray.collider)
                {
                    Vector3 pos = transform.position;
                    pos.z -= speed;
                    transform.position = pos;
                    if (orientation == 1) Debug.DrawRay(transform.position, -transform.forward * 1.0f, Color.green);
                    else Debug.DrawRay(transform.position, transform.right * 2.5f, Color.green);
                }
                else if (orientation == 1) Debug.DrawRay(transform.position, -transform.forward * ray.distance, Color.red);
                else Debug.DrawRay(transform.position, transform.right * ray.distance, Color.red);
            }
            else if (Input.GetKey(Left))
            {
                RaycastHit ray;
                if (orientation == 1) Physics.Raycast(transform.position, -transform.right, out ray, 2.5f, 1 << LayerMask.NameToLayer("Walls"));
                else Physics.Raycast(transform.position, -transform.forward, out ray, 1.0f, 1 << LayerMask.NameToLayer("Walls"));

                if (!ray.collider)
                {
                    Vector3 pos = transform.position;
                    pos.x -= speed;
                    transform.position = pos;
                    if (orientation == 1) Debug.DrawRay(transform.position, -transform.right * 2.5f, Color.green);
                    else Debug.DrawRay(transform.position, -transform.forward * 1.0f, Color.green);
                }
                else if(orientation == 1) Debug.DrawRay(transform.position, -transform.right * ray.distance, Color.red);
                else Debug.DrawRay(transform.position, -transform.forward * ray.distance, Color.red);
            }
            else if (Input.GetKey(Right))
            {
                RaycastHit ray;
                if (orientation == 1) Physics.Raycast(transform.position, transform.right, out ray, 2.5f, 1 << LayerMask.NameToLayer("Walls"));
                else Physics.Raycast(transform.position, transform.forward, out ray, 1.0f, 1 << LayerMask.NameToLayer("Walls"));
                if (!ray.collider)
                {
                    Vector3 pos = transform.position;
                    pos.x += speed;
                    transform.position = pos;
                    if (orientation == 1) Debug.DrawRay(transform.position, transform.right * 2.5f, Color.green);
                    else Debug.DrawRay(transform.position, transform.forward * 1.0f, Color.green);
                }
                else if (orientation == 1) Debug.DrawRay(transform.position, transform.right * ray.distance, Color.red);
                else Debug.DrawRay(transform.position, transform.forward * ray.distance, Color.red);
            }
        }
    }
}
