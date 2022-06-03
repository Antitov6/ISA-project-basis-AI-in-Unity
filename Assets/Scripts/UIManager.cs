using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    Text totalResources;

    void Start()
    {
        totalResources = GetComponentInChildren<Text>();
    }

    void Update()
    {
        totalResources.text = GetComponent<WorkerStateManager>().resourcesInBag.ToString();
    }
}
