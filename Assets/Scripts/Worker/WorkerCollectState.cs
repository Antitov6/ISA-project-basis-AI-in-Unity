using UnityEngine;

public class WorkerCollectState : WorkerBaseState
{

    float collectionSpeed;
    float carryCapacity;

    public override void EnterState(WorkerStateManager worker)
    {
        Debug.Log("Collect!");
        carryCapacity = worker.carryCapacity;
        collectionSpeed = worker.collectionSpeed;
    }

    public override void UpdateState(WorkerStateManager worker)
    {
        worker.resourcesInBag += collectionSpeed * Time.deltaTime;

        if(worker.resourcesInBag >= carryCapacity)
        {
            worker.SwitchState(worker.DeliverState);
        }
    }

    public override void OnTriggerEnter2D(WorkerStateManager worker, Collider2D other)
    {
        SwitchsStateBasedOnPersonality(worker, other);
    }

    private static void SwitchsStateBasedOnPersonality(WorkerStateManager worker, Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (worker.personality == worker.personalitys[0])
            {
                worker.SwitchState(worker.ShelterState);
            }
            else if ((worker.personality == worker.personalitys[1]))
            {
                worker.SwitchState(worker.AggressiveState);
            }
            else
            {
                // Blijf doorgaan met huidige state
            }
        }
    }
}
