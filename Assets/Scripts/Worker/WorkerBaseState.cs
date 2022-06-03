using UnityEngine;

public abstract class WorkerBaseState
{
    public abstract void EnterState(WorkerStateManager worker);

    public abstract void UpdateState(WorkerStateManager worker);

    public abstract void OnTriggerEnter2D(WorkerStateManager worker, Collider2D collider);
}
