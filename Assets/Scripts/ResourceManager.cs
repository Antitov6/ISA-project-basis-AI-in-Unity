using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{

    public float totalResources;
    [SerializeField] Text totalResourcesText;

    void Start()
    {
        totalResourcesText = GameObject.FindObjectOfType<Canvas>().GetComponentInChildren<Text>();
    }

    void Update()
    {
        totalResourcesText.text = totalResources.ToString("F0");
    }
}
