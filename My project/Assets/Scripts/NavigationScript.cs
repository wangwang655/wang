using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NavigationScript : MonoBehaviour
{
    public GameObject target;
    void Start()
    {
        this.GetComponent<NavMeshAgent>().SetDestination(target.transform.position);
    }

    void Update()
    {
        if (this.transform.position == target.transform.position)
        {
            this.GetComponent<NavMeshAgent>().enabled = false;
        }
    }
}

