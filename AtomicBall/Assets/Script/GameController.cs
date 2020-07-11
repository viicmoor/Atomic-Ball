using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject goal;
    [SerializeField] GameObject goalGreen;
    [SerializeField] GameObject ball;
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;

    [SerializeField] float speedIncrease;
    int roundcounter;
    bool goalReached;
    float counter;

    void Start()
    {
        Vector3 point = transform.position;
        point.x = UnityEngine.Random.Range(minX,maxX);
        point.z = UnityEngine.Random.Range(minY, maxY);
        point.y = 1;
        ball.transform.position = point;

        point.x = UnityEngine.Random.Range(minX, maxX);
        point.z = UnityEngine.Random.Range(minY, maxY);
        point.y = 0.2f;
        goal.transform.position = point;
        roundcounter = 0;
        goalReached = false;
        counter = 0;
    }

    private void Update()
    {
        if (goalReached)
        {
            if (counter < 1.0f) counter += Time.deltaTime;
            else Reposition();
        }
    }

    public void GoalReached()
    {
        goalReached = true;
        goal.SetActive(false);
        goalGreen.transform.position = goal.transform.position;
        goalGreen.SetActive(true);
    }

    private void Reposition()
    {
        Vector3 point = transform.position;
        point.x = UnityEngine.Random.Range(minX, maxX);
        point.z = UnityEngine.Random.Range(minY, maxY);
        point.y = 1;
        ball.transform.position = point;

        point.x = UnityEngine.Random.Range(minX, maxX);
        point.z = UnityEngine.Random.Range(minY, maxY);
        point.y = 0.2f;
        goal.transform.position = point;

        if (roundcounter < 3)
        { 
            roundcounter++;
            ball.GetComponent<Ball>().NextRound(0);
        }
        else
        {
            roundcounter = 0;
            ball.GetComponent<Ball>().NextRound(speedIncrease);
        }
        goal.SetActive(true);
        goalGreen.SetActive(false);
        counter = 0;
        goalReached = false;
    }
}
