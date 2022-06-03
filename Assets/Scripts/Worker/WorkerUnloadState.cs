using UnityEngine;

public class WorkerUnloadState : WorkerBaseState
{
    float unloadSpeed;
    float emptyBag = 0;

    public override void EnterState(WorkerStateManager worker)
    {
        Debug.Log("Unload!");
        unloadSpeed = worker.unloadSpeed;
    }

    public override void UpdateState(WorkerStateManager worker)
    {  

        if (worker.resourcesInBag >= emptyBag)
        {
            worker.resourcesInBag -= unloadSpeed * Time.deltaTime;
            GameObject.FindObjectOfType<ResourceManager>().totalResources += unloadSpeed * Time.deltaTime;
        }
        else
        {
            worker.SwitchState(worker.SearchState);
        }
    }

    public override void OnTriggerEnter2D(WorkerStateManager worker, Collider2D collider)
    {

    }
}
