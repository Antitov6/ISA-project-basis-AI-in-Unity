using UnityEngine;

public class WorkerDeliverState : WorkerBaseState
{

    Vector2 unloadPosition = new Vector2(-7.5f, 0);
    float movementSpeed;

    public override void EnterState(WorkerStateManager worker)
    {
        Debug.Log("Deliver!");
        movementSpeed = worker.CalculateMovementSpeed();
    }

    public override void UpdateState(WorkerStateManager worker)
    {
        if ((Vector2.Distance(worker.transform.position, unloadPosition)) > 0.1f)
        {
            var step = movementSpeed * Time.deltaTime;
            worker.transform.position = Vector2.MoveTowards(worker.transform.position, unloadPosition, step);
        }
        else
        {
            worker.SwitchState(worker.UnloadState);
        }
    }

    public override void OnTriggerEnter2D(WorkerStateManager worker, Collider2D collider)
    {

    }
}
