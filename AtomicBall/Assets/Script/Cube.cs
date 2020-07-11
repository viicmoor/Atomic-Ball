using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;
    [SerializeField] float speed;
    bool movement;
    Vector3 direction;
    Vector3 maxPoint;
    Vector3 minPoint;

    void Start()
    {
        movement = false;
        direction = Vector3.zero;
        maxPoint = new Vector3(maxX,transform.position.y,maxY);
        minPoint = new Vector3(minX, transform.position.y, minY);
    }

    // Update is called once per frame
    void Update()
    {
        if (movement && Time.deltaTime > 0)
        {
            /*RaycastHit up;
            RaycastHit down;
            RaycastHit left;
            RaycastHit right;

            Physics.Raycast(transform.position,transform.forward,out up,2.0f,1<<LayerMask.NameToLayer("Pit"));
            Physics.Raycast(transform.position, -transform.forward, out down, 2.0f, 1 << LayerMask.NameToLayer("Pit"));
            Physics.Raycast(transform.position, -transform.right, out left, 2.0f, 1 << LayerMask.NameToLayer("Pit"));
            Physics.Raycast(transform.position, transform.forward, out right, 2.0f, 1 << LayerMask.NameToLayer("Pit"));

            if (up.collider) Debug.DrawRay(transform.position, transform.forward * up.distance, Color.red);
            else Debug.DrawRay(transform.position, transform.forward * 2.0f, Color.green);

            if (down.collider) Debug.DrawRay(transform.position, -transform.forward * down.distance, Color.red);
            else Debug.DrawRay(transform.position, -transform.forward * 2.0f, Color.green);

            if (left.collider) Debug.DrawRay(transform.position, -transform.right * left.distance, Color.red);
            else Debug.DrawRay(transform.position, -transform.right * 2.0f, Color.green);

            if (right.collider) Debug.DrawRay(transform.position, transform.right * right.distance, Color.red);
            else Debug.DrawRay(transform.position, transform.right * 2.0f, Color.green);

            if (up.collider || down.collider || left.collider || right.collider) NextRound();*/
            //if (direction != Vector3.zero) transform.position += direction * speed;
        }
    }

    public void ActivateMovement() => movement = true;

    public void NextRound()
    {
        if (movement)
        {
            //Debug.Log("New point");
            Vector3 point;
            point.x = UnityEngine.Random.Range(-direction.x -(direction.x/2), -direction.x +(direction.x/2));
            point.y = transform.position.y;
            point.z = UnityEngine.Random.Range(-direction.z - (direction.z / 2), -direction.z + (direction.z / 2));
            direction = (transform.position - point).normalized;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 9) NextRound();
        //Debug.Log(collision.gameObject.layer);
    }
}
