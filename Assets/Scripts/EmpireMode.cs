using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpireMode : MonoBehaviour
{

    public int empireMode;
    int defendMode = 1;
    int stayMode = 2;
    int attackMode = 3;

    WorkerStateManager[] workers;

    private void Awake()
    {
        empireMode = stayMode;
    }

    void Start()
    {

    }


    void Update()
    {
        
    }

    public void DefendMode()
    {
            empireMode = defendMode;

            workers = GameObject.FindObjectsOfType<WorkerStateManager>();

            foreach (var worker in workers)
            {
                worker.GetComponent<WorkerStateManager>().DefendMode();
            }
    }

    public void StayMode()
    {
        empireMode = stayMode;

        workers = GameObject.FindObjectsOfType<WorkerStateManager>();

        foreach (var worker in workers)
        {
            worker.GetComponent<WorkerStateManager>().StayOrAttackMode();
        }
    }

    public void AttackMode()
    {
        empireMode = attackMode;

        workers = GameObject.FindObjectsOfType<WorkerStateManager>();

        foreach (var worker in workers)
        {
            worker.GetComponent<WorkerStateManager>().StayOrAttackMode();
        }
    }
}
