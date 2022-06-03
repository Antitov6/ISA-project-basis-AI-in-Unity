using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    WorkerStateManager target;
    float movementSpeed = 1;

    void Start()
    {
        target = GameObject.FindObjectOfType<WorkerStateManager>();
    }

    void Update()
    {
        var step = movementSpeed * Time.deltaTime;
        if(Vector2.Distance(transform.position, target.transform.position) >= 1.5f)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, step);
        }

        if (transform.position.x <= -3.5f)
        {
            Destroy(gameObject);
        }
    }
}
