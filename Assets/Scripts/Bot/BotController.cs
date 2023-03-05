using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BotController : MonoBehaviour
{
    [SerializeField] private Transform movePosition;
    [SerializeField] private NavMeshAgent nav;

    
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nav.destination = movePosition.position;
    }
}
