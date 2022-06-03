using UnityEngine;

public class WorkerSearchState : WorkerBaseState
{
    Vector2 collectibleResource;
    float movementSpeed;

    public override void EnterState(WorkerStateManager worker)
    {
        Debug.Log("Search!");
        movementSpeed = worker.CalculateMovementSpeed();
        collectibleResource = worker.collectibleResource.transform.position;
    }

    public override void UpdateState(WorkerStateManager worker)
    {
        /*
        foreach (var collectibleResource in worker.collectibleResources)
        {
            if (collectibleResource.occupied == false)
            {
                if ((Vector2.Distance(worker.transform.position, collectibleResource.transform.position)) > 0.8f)
                {
                    var step = movementSpeed * Time.deltaTime;
                    worker.transform.position = Vector2.MoveTowards(worker.transform.position, collectibleResource.transform.position, step);
                }
                else
                {
                    worker.SwitchState(worker.CollectState);
                    collectibleResource.occupied = true;
                }
            }
        }
        */

        if ((Vector2.Distance(worker.transform.position, collectibleResource)) > 0.5f)
        {
            var step = movementSpeed * Time.deltaTime;
            worker.transform.position = Vector2.MoveTowards(worker.transform.position, collectibleResource, step);
        }
        else
        {
            worker.SwitchState(worker.CollectState);
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
