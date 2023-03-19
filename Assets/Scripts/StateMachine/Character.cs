using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    [SerializeField] public Transform movePos;
    [SerializeField] public NavMeshAgent nav;
    public int brickCount = 0;
    private IState<Character> currentState;
    public static string TAG_PLATFORM = "Platform";
    public List<Transform> brickPool = new List<Transform>();
    public ColorType currentColor;
    

    private void Start()
    {
        currentColor = this.GetComponent<Bot>().currentColor;
        ChangeState(new IdleState());
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(TAG_PLATFORM))
        {
            PlatformTrigger plat = other.GetComponent<PlatformTrigger>();
            brickPool = plat.grid.GetAllBrickTranformByColor(currentColor);
            Debug.Log(brickPool.Count);
        }
    }
    public void ChangeState(IState<Character> state)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }

        currentState = state;

        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }
    public void MoveToward(Transform moveToPos)
    {
        nav.destination = moveToPos.position;
    }
}
