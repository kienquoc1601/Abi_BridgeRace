using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrickController : MonoBehaviour
{
    //Brick stack variables ------
    public StackBrick brickPrefab;
    public Transform brickParent;
    public int stack;
    public List<StackBrick> bricks = new List<StackBrick>();
    private ColorType currentColor;

    void Start()
    {
        currentColor = this.gameObject.GetComponent<Player>().currentColor;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collider)
    {
        GameObject other = collider.gameObject;
        if (other.tag == "Brick")
        {
            if (other.GetComponent<Brick>().currentColor == currentColor)
            {
                Debug.Log("bbb");
                AddBrick();
            }
        }
    }

    public void AddBrick()
    {
        //make brick and set parent
        StackBrick brick = Instantiate(brickPrefab, brickParent);
        //set brickPoint height
        brick.transform.localPosition = new Vector3(0, stack * 0.2f, 0);
        brick.GetComponent<MeshRenderer>().material = this.gameObject.GetComponent<Player>().colorData.GetColor(currentColor);
        bricks.Add(brick);
        stack++;
    }

    public void RemoveBrick()
    {
        if (bricks.Count > 0)
        {
            StackBrick brick = bricks[bricks.Count - 1];
            bricks.RemoveAt(bricks.Count - 1);
            Destroy(brick.gameObject);
            stack--;

        }
        else
        {
            //UIManagerScript.Instance.ShowLoseMenu();
        }
    }
}
