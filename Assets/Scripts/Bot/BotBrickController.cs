using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotBrickController : MonoBehaviour
{
    //public Bot bot;
    public Character character;
    public StackBrick brickPrefab;
    public Transform brickParent;
    public int stack;
    public List<StackBrick> bricks = new List<StackBrick>();
    private ColorType currentColor;

    public static string TAG_BRICK = "Brick";
    public static string TAG_STAIR = "Stair";
    // Start is called before the first frame update
    void Start()
    {
        currentColor = character.currentColor;
    }

    
    private void OnTriggerEnter(Collider collider)
    {
        GameObject other = collider.gameObject;
        if (collider.CompareTag(TAG_BRICK))
        {
            Brick brick = collider.GetComponent<Brick>();
            if (brick != null)
            {
                if (brick.currentColor == currentColor)
                {
                    AddBrick();
                    brick.InvisibleState();
                }
            }
        }
        if (collider.CompareTag(TAG_STAIR))
        {
            other.GetComponent<Stair>().BuildStair(currentColor);
            RemoveBrick();
        }
    }

    public void AddBrick()
    {
        //make brick and set parent
        StackBrick brick = Instantiate(brickPrefab, brickParent);
        //set brickPoint height
        brick.transform.localPosition = new Vector3(0, character.brickCount * 0.2f, 0);
        brick.ren.material = character.colorData.GetColor(currentColor);
        bricks.Add(brick);
        character.brickCount++;
    }

    public void RemoveBrick()
    {
        if (bricks.Count > 0)
        {
            StackBrick brick = bricks[bricks.Count - 1];
            bricks.RemoveAt(bricks.Count - 1);
            Destroy(brick.gameObject);
            character.brickCount--;

        }
        else
        {
            //UIManagerScript.Instance.ShowLoseMenu();
        }
    }
}
