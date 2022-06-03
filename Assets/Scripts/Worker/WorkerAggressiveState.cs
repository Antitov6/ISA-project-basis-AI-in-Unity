using UnityEngine;

public class WorkerAggressiveState : WorkerBaseState
{
    float movementSpeed;
    GameObject[] multipleEnemys;
    Transform closestEnemy;
    float timeBetweenAttack;
    float startTimeBetweenAttack;

    public override void EnterState(WorkerStateManager worker)
    {
        Debug.Log("Aggressive!");
        movementSpeed = worker.CalculateMovementSpeed();
        closestEnemy = null;
        startTimeBetweenAttack = worker.startTimeBetweenAttack;
    }

    public override void UpdateState(WorkerStateManager worker)
    {
        closestEnemy = GetClosestEnemy(worker);

        MoveToAndAttack(worker);
    }

    public override void OnTriggerEnter2D(WorkerStateManager worker, Collider2D other)
    {

    }

    private Transform GetClosestEnemy(WorkerStateManager worker)
    {
        multipleEnemys = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;
        Transform trans = null;

        foreach (GameObject enemy in multipleEnemys)
        {
            float currentDistance;
            currentDistance = Vector2.Distance(worker.transform.position, enemy.transform.position);
            if(currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                trans = enemy.transform;
            }           
        }
        return trans;
    }

    private void MoveToAndAttack(WorkerStateManager worker)
    {
        if(closestEnemy)
        {
            if (Vector2.Distance(worker.transform.position, closestEnemy.position) < 4)
            {
                if (Vector2.Distance(worker.transform.position, closestEnemy.position) > 1.5f)
                {
                    var step = movementSpeed * Time.deltaTime;
                    worker.transform.position = Vector2.MoveTowards(worker.transform.position, closestEnemy.position, step);
                }
                else
                {
                    if (timeBetweenAttack <= 0)
                    {
                        closestEnemy.gameObject.GetComponent<Health>().SubtractHealth(worker.attackDamage);
                        timeBetweenAttack = startTimeBetweenAttack;
                    }
                    else
                    {
                        timeBetweenAttack -= Time.deltaTime;
                    }
                }
            }
            else
            {
                worker.SwitchState(worker.SearchState);
            }
        }
        else
        {
            worker.SwitchState(worker.SearchState);
        }
    }
}
