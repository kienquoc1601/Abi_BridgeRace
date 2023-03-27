using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public static string TAG_PLAYER = "Player";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag(TAG_PLAYER))
        {
            UIManager.Ins.OpenUI<Win>().score.text = collider.GetComponent<PlayerBrickController>().stack.ToString();
            
        }
    }
}