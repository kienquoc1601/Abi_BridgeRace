using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrickController : MonoBehaviour
{
    //Brick stack variables ------
    public Player player;
    public StackBrick brickPrefab;
    public Transform brickParent;
    public int stack;
    public List<StackBrick> bricks = new List<StackBrick>();
    private ColorType currentColor;

    public static string TAG_BRICK = "Brick";
    public static string TAG_STAIR = "Stair";
    public static string TAG_BOT = "Bot";
    void Start()
    {
        currentColor = player.currentColor;
    }
    // Update is called once per frame
    
    
    
    private void OnTriggerEnter(Collider collider)
    {
        GameObject other = collider.gameObject;
        if (collider.CompareTag(TAG_BRICK))
        {
            Brick brick = collider.GetComponent<Brick>();
            if(brick != null)
            {
                if(brick.currentColor == currentColor)
                {
                    AddBrick();
                    brick.InvisibleState();
                }
            }
        }
        if(collider.CompareTag(TAG_STAIR))
        {
            if(other.GetComponent<Stair>().currentColor != player.currentColor)
            {
                other.GetComponent<Stair>().BuildStair(currentColor);
                RemoveBrick();

            }
            
        }
        if (collider.CompareTag(TAG_BOT))
        {
            if (other.GetComponent<BotBrickController>().stack <= stack)
            {
                StartCoroutine(other.GetComponent<Bot>().KnockDown());
                
            }else if (other.GetComponent<BotBrickController>().stack > stack)
            {
                StartCoroutine(player.KnockDown());
            }
        }
    }

    public void AddBrick()
    {
        //make brick and set parent
        StackBrick brick = Instantiate(brickPrefab, brickParent);
        //set brickPoint height
        brick.transform.localPosition = new Vector3(0, stack * 0.2f, 0);
        brick.ren.material = player.colorData.GetColor(currentColor);
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
