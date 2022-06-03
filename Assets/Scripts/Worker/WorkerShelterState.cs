using UnityEngine;

public class WorkerShelterState : WorkerBaseState
{
    float unloadSpeed;
    float emptyBag = 0;

    Vector2 unloadPosition = new Vector2(-7.5f, 0);
    float movementSpeed;

    public override void EnterState(WorkerStateManager worker)
    {
        Debug.Log("Shelter!");
        movementSpeed = worker.CalculateMovementSpeed();
        unloadSpeed = worker.unloadSpeed;
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
            if (worker.resourcesInBag >= emptyBag)
            {
                worker.resourcesInBag -= unloadSpeed * Time.deltaTime;
                GameObject.FindObjectOfType<ResourceManager>().totalResources += unloadSpeed * Time.deltaTime;
            }
            else
            {
                Debug.Log("Finsihed and idle");
                // Idle, waiting for order
            }
        }       

        //if() // Als mode Deffend niet actief is 
        {
            //worker.SwitchState(worker.SearchState);
        }
    }

    public override void OnTriggerEnter2D(WorkerStateManager worker, Collider2D collider)
    {

    }
}
