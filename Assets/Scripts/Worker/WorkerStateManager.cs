using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkerStateManager : MonoBehaviour
{
    public float resourcesInBag = 0;
    public float carryCapacity = 15;
    public float collectionSpeed = 1.5f;
    public float unloadSpeed = 2f;
    //public CollectibleResource[] collectibleResources;
    public GameObject collectibleResource;
    public float startTimeBetweenAttack = 0.5f;
    public float attackDamage = 5;
    [SerializeField] float movementSpeed;
    float movementSpeedMax = 2f;
    public string[] personalitys = new string[] {"Scared", "Aggressive", "Normale"};
    public string personality;
    public int workerMode;

    public WorkerBaseState currentState;
    public WorkerSearchState SearchState = new WorkerSearchState();
    public WorkerCollectState CollectState = new WorkerCollectState();
    public WorkerDeliverState DeliverState = new WorkerDeliverState();
    public WorkerUnloadState UnloadState = new WorkerUnloadState();
    public WorkerShelterState ShelterState = new WorkerShelterState();
    public WorkerAggressiveState AggressiveState = new WorkerAggressiveState();


    void Start()
    {
        StartState();
        personality = personalitys[Random.Range(0, personalitys.Length)];
        ColorBasedOnPersonality();
        //collectibleResources = GameObject.FindObjectsOfType<CollectibleResource>();
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        currentState.OnTriggerEnter2D(this, collider);
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(WorkerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    public float CalculateMovementSpeed()
    {
        movementSpeed = Mathf.Clamp(((carryCapacity - resourcesInBag) / carryCapacity) * movementSpeedMax, movementSpeedMax / 2, movementSpeedMax);
        return movementSpeed;
    }

    private void ColorBasedOnPersonality()
    {
        if (personality == personalitys[0])
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
        }
        else if ((personality == personalitys[1]))
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0.3f, 0);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0.65f, 0);
        }
    }

    void StartState()
    {
        workerMode = GameObject.FindObjectOfType<EmpireMode>().empireMode;

        if (workerMode == 1)
        {
            DefendMode();
        }
        else
        {
            currentState = SearchState;
            currentState.EnterState(this);
        }
    }

    public void DefendMode()
    {
        currentState = ShelterState;
        currentState.EnterState(this);
    }

    public void StayOrAttackMode()
    {
        if (currentState == ShelterState)
        {
            currentState = SearchState;
            currentState.EnterState(this);
        }
    }
}
